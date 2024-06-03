using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Networking
{
	public abstract class AbstractServer(string host, int port)
	{
		private TcpListener server;
		private string host = host;
		private int port = port;

		public void Start()
		{
			IPAddress adr = IPAddress.Parse(host);
			IPEndPoint ep = new IPEndPoint(adr, port);
			server = new TcpListener(ep);
			server.Start();
			while (true)
			{
				Console.WriteLine("Waiting for clients ...");
				TcpClient client = server.AcceptTcpClient();
				Console.WriteLine("Client connected ...");
				processRequest(client);
			}
		}

		public abstract void processRequest(TcpClient client);

	}


	public abstract class ConcurrentServer(string host, int port) : AbstractServer(host, port)
	{
		public override void processRequest(TcpClient client)
		{

			Thread t = createWorker(client);
			t.Start();

		}

		protected abstract Thread createWorker(TcpClient client);
	}
	
	public class CompetitionJsonConcurrentServer : ConcurrentServer
	{
		private IServices server;
		private CompetitionClientJsonWorker worker;
		public CompetitionJsonConcurrentServer(string host, int port, IServices server) : base(host, port)
		{
			this.server = server;
			Console.WriteLine("JsonConcurrentServer...");
		}

		protected override Thread createWorker(TcpClient client)
		{
			worker = new CompetitionClientJsonWorker(server, client);
			return new Thread(new ThreadStart(worker.Run));
		}
	}
}
