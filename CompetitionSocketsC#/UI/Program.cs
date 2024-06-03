using Networking;
using Services;
using System.Configuration;

namespace UI
{
	public class Program
	{
		private static int DEFAULT_PORT = 55556;
		private static String DEFAULT_IP = "127.0.0.1";
		static Program()
		{
		}

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Console.WriteLine("Reading properties from app.config ...");
			int port = DEFAULT_PORT;
			String ip = DEFAULT_IP;
			String portS = ConfigurationManager.AppSettings["port"];
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
			String ipS = ConfigurationManager.AppSettings["ip"];

			if (ipS == null)
			{
				Console.WriteLine("Port property not set. Using default value " + DEFAULT_IP);
			}

			Console.WriteLine("Using  server on IP {0} and port {1}", ip, port);
			IServices server = new CompetitionServerJsonProxy(ip, port);
			ClientCtrl ctrl = new ClientCtrl(server);
			LoginForm loginForm = new LoginForm(ctrl);
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(loginForm);

		}
	}
}