using Model;
using Networking.dto;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
	public class CompetitionServerJsonProxy : IServices
	{
		private string Host;
		private int Port;

		private IObserver Client;
		private NetworkStream Stream;

		private TcpClient Connection;
		private Queue<Response> Responses;
		private volatile bool Finished;
		private EventWaitHandle _waitHandle;
		private StreamReader Input;
		private StreamWriter Output;
		public CompetitionServerJsonProxy(string ip, int port)
		{
			this.Host = ip;
			this.Port = port;
			Responses = new Queue<Response>();
		}

		public Contestant Add(string name, string age, string cnp)
		{
			throw new NotImplementedException();
		}

		public void AddOperator(string username, string password, string email, string city)
		{
			InitializeConnection();

			Console.WriteLine("Adding operator...");
			Operator op = new Operator(username, password, email, city);
			Request req = JsonProtocolUtils.CreateRegisterRequest(op);
			SendRequest(req);
			Response response = ReadResponse();
			if(response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
		}

		public void AddParticipation(Contestant contestant, Contest contest)
		{
			Participation participation = new Participation(contest, contestant, DateTime.UtcNow);
			Request req = JsonProtocolUtils.CreateAddParticipationRequest(participation);

			SendRequest(req);
			Response response = ReadResponse();
			if(response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
		}

		public List<ContestantServiceDTO> FindAllContestantsByContestWithParticipationCount(int idContest)
		{
			Console.WriteLine("Finding all contestants by contest with participation count: " + idContest + "(PROXY)");
			Request req = JsonProtocolUtils.createGetContestantsByContestWithParticipationCountRequest(idContest);

			SendRequest(req);
			Response response = ReadResponse();
			if (response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
			return DTOUtils.GetContestantServiceDTOListFromDTO(response.Contestants);
		}

		public List<Contest> FindAllContestsByGroup(int idGroup)
		{
			Console.WriteLine("Finding all contests by group: " + idGroup);
			Request req = JsonProtocolUtils.createGetContestsByGroupRequest(idGroup);

			SendRequest(req);
			Response response = ReadResponse();
			if(response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
			return DTOUtils.GetContestListFromDTO(response.Contests);
		}

		public List<ContestServiceDTO> FindAllContestsByGroupWithParticipationCount(int idGroup)
		{
			Console.WriteLine("Finding all contests by group with participation count: " + idGroup + "(PROXY)");
			Request req = JsonProtocolUtils.createGetContestsByGroupWithParticipationCountRequest(idGroup);

			SendRequest(req);
			Response response = ReadResponse();
			if(response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
			return DTOUtils.GetContestServiceDTOListFromDTO(response.Contests);
		}

		public Group FindGroupByAge(int age)
		{
			Console.WriteLine("Finding the group with age: " + age + "(PROXY)");
			Request req = JsonProtocolUtils.createGetGroupByAgeRequest(age);

			SendRequest(req);
			Response response = ReadResponse();
			if (response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
			return DTOUtils.GetGroupListFromDTO(response.Groups)[0];
		}

		public List<Group> FindAllGroups()
		{
			Request req = JsonProtocolUtils.createGetGroupsRequest();

			SendRequest(req);
			Response response = ReadResponse();
			if(response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
			return DTOUtils.GetGroupListFromDTO(response.Groups);
		}

		public void Logout(Operator op, IObserver client)
		{
			Request req = JsonProtocolUtils.CreateLogoutRequest(op);

			SendRequest(req);
			Response response = ReadResponse();
			CloseConnection();
			if(response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				throw new CompetitionException(err);
			}
		}

		public Operator MatchByUserAndPassword(Operator op, IObserver client)
		{
			InitializeConnection();

			Console.WriteLine("Matching operator by user and pass " + op.Username + " " + op.Password);
			Request req = JsonProtocolUtils.CreateLoginRequest(op);
			SendRequest(req);
			Response response = ReadResponse();
			if(response.Type == ResponseType.LOGIN)
			{
				this.Client = client;
				return DTOUtils.GetFromDTO(response.Operator);
			} else
			{
				Console.WriteLine("Error: " + response.ErrorMessage);
				string err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
		}
		public Contestant AddContestant(string name, int age, string cnp)
		{
			Console.WriteLine("Adding contestant " + name +" " + age +" " + cnp);
			Contestant contestant = new Contestant(name, age, cnp);
			Request req = JsonProtocolUtils.CreateAddContestantRequest(contestant);

			SendRequest(req);
			Response response = ReadResponse();
			if (response.Type == ResponseType.ERROR)
			{
				String err = response.ErrorMessage;
				CloseConnection();
				throw new CompetitionException(err);
			}
			return DTOUtils.GetFromDTO(response.Contestant);
		}

		private Response ReadResponse()
		{
			Response response = null;
			try
			{
				_waitHandle.WaitOne();
				lock(Responses)
				{
					response = Responses.Dequeue();
				}
			}
			catch(Exception e)
			{
				Console.WriteLine($"Error: {e}");
			}
			return response;
		}

		private void CloseConnection()
		{
			Finished = true;
			try
			{
				Stream.Close();

				Connection.Close();
				_waitHandle.Close();
			} catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void SendRequest(Request request)
		{
			string req = JsonConvert.SerializeObject(request);
			try
			{
				Output.WriteLine(req);
				Output.Flush();
			} catch(Exception e)
			{
				throw new CompetitionException("Error sending obj " + e.Message, e);
			}
		}
		private void InitializeConnection()
		{
			if (Connection != null && Connection.Connected)
			{
				Console.WriteLine("Already connected!");
				return;
			}
			try
			{
				Connection = new TcpClient(Host, Port);
				Stream = Connection.GetStream();
				Finished = false;
				Input = new StreamReader(Stream);
				Output = new StreamWriter(Stream);
				_waitHandle = new AutoResetEvent(false);
				StartReader();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		private void StartReader()
		{
			Thread tw = new Thread(Run);
			tw.Start();
		}
		public void Run()
		{
			while (!Finished)
			{
				try
				{
					string responseLine = Input.ReadLine();
					if (responseLine == null) // Stream closed
					{
						break;
					}
					Response response = JsonConvert.DeserializeObject(responseLine, typeof(Response)) as Response;
					Console.WriteLine("Response received " + response);
					if(response == null)
					{
						return;
					}
					else if (IsUpdate(response))
					{
						HandleUpdate(response);
					} else
					{
						lock(Responses)
						{
							Responses.Enqueue(response);
						}
						_waitHandle.Set();
					}
				}
				catch (IOException e) 
				{
					Console.WriteLine("Reading error " + e);
				}
				finally
				{
					// Ensure the wait handle is signaled to prevent deadlocks
					//_waitHandle.Set();
				}
			}
		}

		private void HandleUpdate(Response response)
		{
			if(response.Type == ResponseType.PARTICIPATION_NOTIFICATION)
			{
				ParticipationDTO participationDTO = response.Participation;
				Participation participation = DTOUtils.GetFromDTO(participationDTO);
				try
				{
					Client.ParticipationAdded(participation);
				} catch(CompetitionException e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}

		private bool IsUpdate(Response response)
		{
			return response.Type == ResponseType.PARTICIPATION_NOTIFICATION;
		}

	}
}
