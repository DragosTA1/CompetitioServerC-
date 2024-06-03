using Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class OperatorRepository : IOperatorRepository
	{
		private static readonly ILog log = LogManager.GetLogger("OperatorRepository");
		readonly IDictionary<string, string> props;
		IDbConnection? con;
		public OperatorRepository(IDictionary<string, string> props)
		{
			log.Info("Creating OperatorRepository ");
			this.props = props;
		}
		public void Add(Operator op)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering Add with value {0}", op);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "insert into Operators(username, password, email, city) values (@user, @pass, @email, @city)";
				var paramUser = comm.CreateParameter();
				paramUser.ParameterName = "@user";
				paramUser.Value = op.Username;
				comm.Parameters.Add(paramUser);

				var paramPass = comm.CreateParameter();
				paramPass.ParameterName = "@pass";
				paramPass.Value = op.Password;
				comm.Parameters.Add(paramPass);

				var paramEmail = comm.CreateParameter();
				paramEmail.ParameterName = "@email";
				paramEmail.Value = op.Email;
				comm.Parameters.Add(paramEmail);

				var paramCity = comm.CreateParameter();
				paramCity.ParameterName = "@city";
				paramCity.Value = op.City;
				comm.Parameters.Add(paramCity);

				var result = comm.ExecuteNonQuery();
				if (result == 0)
					throw new Exception("No operator added !");
				log.InfoFormat("Added!");
			}
			log.InfoFormat("Exiting Add");
		}

		public void Delete(Operator op)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering Delete with value {0}", op);
			IDbConnection con = DBUtils.GetConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "delete from Operators where id=@id";
				IDbDataParameter paramId = comm.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = op.Id;
				comm.Parameters.Add(paramId);
				var dataR = comm.ExecuteNonQuery();
				if (dataR == 0) throw new Exception("No operator deleted !");
				log.InfoFormat("Deleted!");
			}
			log.InfoFormat("Exiting Delete");
		}

		public Operator? Find(int id)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering Find with value {0}", id);
			IDbConnection con = DBUtils.GetConnection(props);

			using ( var comm = con.CreateCommand())
			{
				comm.CommandText = "select * from Operators where id = @id";
				IDbDataParameter paramId = comm.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = id;
				comm.Parameters.Add(paramId);

				using(var dataR = comm.ExecuteReader())
				{
					if(dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						string username = dataR.GetString(1);
						string password = dataR.GetString(2);
						string email = dataR.GetString(3);
						string city = dataR.GetString(4);

						Operator op = new(username, password, email, city)
						{
							Id = idV
						};
						log.InfoFormat("Found!");
						log.InfoFormat("Exiting Find with value {0}", op);
						return op;
					}
				}
			}
			log.InfoFormat("Exiting Find with value {0}", null);
			return null;
		}

		public List<Operator> FindAll()
		{
			throw new NotImplementedException();
		}

		public Operator? MatchByUserAndPassword(string user, string password)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering MatchByPassword with value {0} and {1}", user, password);
			IDbConnection con = DBUtils.GetConnection(props);

			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select * from Operators where username = @user and password = @password";

				IDbDataParameter paramUser = comm.CreateParameter();
				paramUser.ParameterName = "@user";
				paramUser.Value = user;
				comm.Parameters.Add(paramUser);
				IDbDataParameter paramPass = comm.CreateParameter();
				paramPass.ParameterName = "@password";
				paramPass.Value = password;
				comm.Parameters.Add(paramPass);

				using (var dataR = comm.ExecuteReader())
				{
					if (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						string username = dataR.GetString(1);
						string passwordV = dataR.GetString(2);
						string email = dataR.GetString(3);
						string city = dataR.GetString(4);

						Operator op = new(username, passwordV, email, city)
						{
							Id = idV
						};
						log.InfoFormat("Matched!");
						log.InfoFormat("Exiting MatchByPassword with value {0}", op);
						return op;
					}
				}
			}
			log.InfoFormat("Exiting MatchByPassword with null value");
			return null;
		}

		public void Update(Operator op, int id)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering Update with value {0}", op);
			IDbConnection con = DBUtils.GetConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "update Operators set username=@user, password=@pass, email=@email, city=@city where id=@id";
				IDbDataParameter paramUser = comm.CreateParameter();
				paramUser.ParameterName = "@user";
				paramUser.Value = op.Username;
				comm.Parameters.Add(paramUser);

				IDbDataParameter paramPass = comm.CreateParameter();
				paramPass.ParameterName = "@pass";
				paramPass.Value = op.Password;
				comm.Parameters.Add(paramPass);

				IDbDataParameter paramEmail = comm.CreateParameter();
				paramEmail.ParameterName = "@email";
				paramEmail.Value = op.Email;
				comm.Parameters.Add(paramEmail);

				IDbDataParameter paramCity = comm.CreateParameter();
				paramCity.ParameterName = "@city";
				paramCity.Value = op.City;
				comm.Parameters.Add(paramCity);

				IDbDataParameter paramId = comm.CreateParameter();
				paramId.ParameterName = "@id";
				paramId.Value = id;
				comm.Parameters.Add(paramId);

				var dataR = comm.ExecuteNonQuery();
				if (dataR == 0) throw new Exception("No operator updated !");
				log.InfoFormat("Updated!");
			}
			log.InfoFormat("Exiting Update");
		}
	}
}
