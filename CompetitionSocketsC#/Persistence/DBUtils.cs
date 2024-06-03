using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Persistence
{
	public static class DBUtils
	{
		private static IDbConnection? instance = null;
		public static IDbConnection GetConnection(IDictionary<string, string> props)
		{
			if (instance == null || instance.State == System.Data.ConnectionState.Closed)
			{
				instance = GetNewConnection(props);
				instance.Open();
			}
			return instance;
		}
		private static IDbConnection GetNewConnection(IDictionary<string, string> props)
		{
			return ConnectionFactory.getInstance().createConnection(props);
		}
	}

	public abstract class ConnectionFactory
	{
		protected ConnectionFactory()
		{
		}

		private static ConnectionFactory instance;

		public static ConnectionFactory getInstance()
		{
			if (instance == null)
			{

				Assembly assem = Assembly.GetExecutingAssembly();
				Type[] types = assem.GetTypes();
				foreach (var type in types)
				{
					if (type.IsSubclassOf(typeof(ConnectionFactory)))
						instance = (ConnectionFactory)Activator.CreateInstance(type);
				}
			}
			return instance;
		}

		public abstract IDbConnection createConnection(IDictionary<string, string> props);
	}

	public class SQLiteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection(IDictionary<string, string> props)
		{
			// Windows SQLite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
			//String connectionString = "Data Source=../../../../db/Competition.db;Version=3";
			string connectionString = props["ConnectionString"];
			Console.WriteLine("SQLite ---Se deschide o conexiune la  ... {0}", connectionString);
			return new SQLiteConnection(connectionString);
		}
	}
}
