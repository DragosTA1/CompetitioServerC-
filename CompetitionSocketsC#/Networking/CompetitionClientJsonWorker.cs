using Microsoft.AspNetCore.Builder;
using Model;
using Networking.dto;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
	public class CompetitionClientJsonWorker : IObserver
	{
		private IServices server;
		private TcpClient connection;

		private NetworkStream stream;
		private StreamReader input;
		private StreamWriter output;
		private volatile bool connected;
		public CompetitionClientJsonWorker(IServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				stream = connection.GetStream();
				input = new StreamReader(stream);
				output = new StreamWriter(stream);
				connected = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}
		public void ParticipationAdded(Participation participation)
		{
			Response resp = JsonProtocolUtils.CreateParticipationAddedResponse(participation);
			Console.WriteLine("Participation added " + participation);
			SendResponse(resp);
		}
		private static Response okResponse = JsonProtocolUtils.CreateOkResponse();
		public virtual void Run()
		{
			while (connected)
			{
				try
				{
					string requestLine = input.ReadLine();
					Request request = JsonConvert.DeserializeObject(requestLine, typeof(Request)) as Request;
					Console.WriteLine("Request received " + request);
					Response response = HandleRequest(request);
					if (response != null)
					{
						Console.WriteLine("Resp prepared!");
						SendResponse(response);
					}
					else
					{
						Console.WriteLine("No resp prepared!");
					}
				}
				catch (IOException e)
				{
					Console.WriteLine(e);
				}
				Console.WriteLine("Sleeping...");
				Thread.Sleep(1000);
			}
		}
		private void SendResponse(Response response)
		{
			Console.WriteLine("Sending response " + response);
			lock (output)
			{
				string responseLine = JsonConvert.SerializeObject(response);
				output.WriteLine(responseLine);
				output.Flush();
			}
		}

		private Response HandleRequest(Request request)
		{
			Response response = null;
			if (request.Type.Equals(RequestType.LOGIN))
			{
				Console.WriteLine("Login request...");
				OperatorDTO operatorDTO = request.Operator;
				Operator op = DTOUtils.GetFromDTO(operatorDTO);
				try
				{
					op = server.MatchByUserAndPassword(op, this);
					if (op != null)
					{
						return JsonProtocolUtils.CreateLoginResponse(op);
					}
					else
					{
						throw new CompetitionException("User or password are wrong!");
					}
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if (request.Type == RequestType.GET_GROUPS)
			{
				Console.WriteLine("Get groups request...");
				try
				{
					List<Group> groups = server.FindAllGroups();
					return JsonProtocolUtils.CreateGetGroupsResponse(groups);
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if (request.Type == RequestType.GET_CONTESTS_AND_PARTICIPATION_COUNT_BY_GROUP)
			{
				Console.WriteLine("Get contests and participation count by group request...");
				int id = request.GroupID;
				try
				{
					List<ContestServiceDTO> contestServiceDTOs = server.FindAllContestsByGroupWithParticipationCount(id);
					return JsonProtocolUtils.createGetContestsByGroupWithParticipationCountResponse(contestServiceDTOs);
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if (request.Type == RequestType.GET_CONTESTANTS_AND_PARTICIPATION_COUNT_BY_CONTEST)
			{
				Console.WriteLine("Get contestants and participation count by contest request...");
				int id = request.ContestID;
				try
				{
					List<ContestantServiceDTO> contestantServiceDTOs = server.FindAllContestantsByContestWithParticipationCount(id);
					return JsonProtocolUtils.createGetContestantsByGroupWithParticipationCountResponse(contestantServiceDTOs);
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if (request.Type == RequestType.GET_GROUP_BY_AGE)
			{
				Console.WriteLine("Get group by age request...");
				int age = request.GroupAge;
				try
				{
					return JsonProtocolUtils.createGetGroupByAgeResponse(server.FindGroupByAge(age));
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if (request.Type == RequestType.GET_CONTESTS_BY_GROUP)
			{
				Console.WriteLine("Get contests by group age request...");
				int id = request.GroupID;
				try
				{
					return JsonProtocolUtils.CreateGetContestsByGroupResponse(server.FindAllContestsByGroup(id));
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if (request.Type == RequestType.ADD_CONTESTANT)
			{
				Console.WriteLine("Add contestant request...");
				try
				{
					ContestantDTO contestantDTO = request.Contestant;
					Contestant c = server.AddContestant(contestantDTO.ContestantServiceDTO.Name, contestantDTO.ContestantServiceDTO.Age, contestantDTO.ContestantServiceDTO.CNP);
					return JsonProtocolUtils.CreateAddContestantResponse(c);
				}
				catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if(request.Type == RequestType.ADD_PARTICIPATION)
			{
				Console.WriteLine("Add participation request...");
				try
				{
					ParticipationDTO participationDTO = request.Participation;
					server.AddParticipation(participationDTO.Contestant, participationDTO.Contest);
					return okResponse;
				} catch (CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if(request.Type == RequestType.REGISTER)
			{
				Console.WriteLine("Registering operator request...");
				try
				{
					Operator op = DTOUtils.GetFromDTO(request.Operator);
					server.AddOperator(op.Username, op.Password, op.Email, op.City);
					return okResponse;
				} catch(CompetitionException e)
				{
					connected = false;
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			if(request.Type == RequestType.LOGOUT)
			{
				Console.WriteLine("Logout request...");
				OperatorDTO operatorDTO = request.Operator;
				Operator op = DTOUtils.GetFromDTO(operatorDTO);
				try
				{
					server.Logout(op, this);
					connected = false;
					return okResponse;
				}
				catch (CompetitionException e)
				{
					return JsonProtocolUtils.CreateErrorResponse(e.Message);
				}
			}
			return response;
		}
	}
}