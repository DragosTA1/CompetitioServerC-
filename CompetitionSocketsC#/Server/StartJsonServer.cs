using Networking;
using Persistence;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class StartJsonServer
	{
		private static int DEFAULT_PORT = 55555;
		private static string DEFAULT_IP = "127.0.0.1";

		public static void Main(string[] args)
		{
			// Your code here
			Console.WriteLine("Reading properties from app.config...");
			int port = DEFAULT_PORT;
			string ip = DEFAULT_IP;
			string portS = ConfigurationManager.AppSettings["port"];
			if (portS == null)
			{
				Console.WriteLine("Port property not set. Using default value " + DEFAULT_PORT);
			}
			else
			{
				bool result = Int32.TryParse(portS, out port);
				if (!result)
				{
					Console.WriteLine("Port property not a number. Using default value " + DEFAULT_PORT);
					port = DEFAULT_PORT;
					Console.WriteLine("Portul " + port);
				}
			}
			string ipS = ConfigurationManager.AppSettings["ip"];

			if (ipS == null)
			{
				Console.WriteLine("Port property not set. Using default value " + DEFAULT_IP);
			}
			Console.WriteLine("Configuration Settings for database {0}", GetConnectionStringByName("Competition"));
			IDictionary<string, string> props = new SortedList<string, string>();
			props.Add("ConnectionString", GetConnectionStringByName("Competition"));

			EFContext eFContext = new EFContext();
			IOperatorRepository operatorRepository = new OperatorRepositoryEF(eFContext);
			IContestantRepository contestantRepository = new ContestantRepository(props);
			IContestRepository contestRepository = new ContestRepository(props);
			IParticipationRepository participationRepository = new ParticipationRepository(props);
			IGroupRepository groupRepository = new GroupRepository(props);

			IServices serverImpl = new ServicesImpl(operatorRepository, contestantRepository, contestRepository, groupRepository, participationRepository);
			Console.Write("Starting server on IP {0} and port {1}\n", ip, port);

			AbstractServer server = new CompetitionJsonConcurrentServer(ip, port, serverImpl);
			server.Start();
			Console.WriteLine("Server started...");
			Console.ReadLine();
		}

		static string GetConnectionStringByName(string name)
		{
			// Assume failure.
			string returnValue = null;

			// Look for the name in the connectionStrings section.
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

			// If found, return the connection string.
			if (settings != null)
				returnValue = settings.ConnectionString;

			return returnValue;
		}
	}
}