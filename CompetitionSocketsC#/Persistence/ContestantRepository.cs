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
	public class ContestantRepository : IContestantRepository
	{
		private static readonly ILog log = LogManager.GetLogger("ContestantRepository");
		readonly IDictionary<string, string> props;
		IDbConnection? con;
		public ContestantRepository(IDictionary<string, string> props)
		{
			log.Info("Creating ContestantRepository ");
			this.props = props;
		}
		public Contestant Add(Contestant contestant)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering Add with value {0}", contestant);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "insert into Contestants(age,name,cnp) values (@age,@name,@cnp); SELECT last_insert_rowid()";
				var paramAge = comm.CreateParameter();
				paramAge.ParameterName = "@age";
				paramAge.Value = contestant.Age;
				comm.Parameters.Add(paramAge);

				var paramName = comm.CreateParameter();
				paramName.ParameterName = "@name";
				paramName.Value = contestant.Name;
				comm.Parameters.Add(paramName);

				var paramCNP = comm.CreateParameter();
				paramCNP.ParameterName = "@cnp";
				paramCNP.Value = contestant.CNP;
				comm.Parameters.Add(paramCNP);


				object result = comm.ExecuteScalar();
				if (result == null)
					throw new Exception("No contestant added !");
				contestant.Id = Convert.ToInt32(result);
				log.InfoFormat("Added!");
			}
			log.InfoFormat("Exiting Add");
			return contestant;
		}

		public void Delete(Contestant entity)
		{
			throw new NotImplementedException();
		}

		public Contestant Find(int id)
		{
			throw new NotImplementedException();
		}

		public List<Contestant> FindAll()
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAll");
			IDbConnection con = DBUtils.GetConnection(props);
			List<Contestant> contestants = new List<Contestant>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select * from Contestants";

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int age = dataR.GetInt32(1);
						string name = dataR.GetString(2);
						string cnp = dataR.GetString(3);

						Contestant contestant = new Contestant(name, age, cnp);
						contestant.Id = idV;

						contestants.Add(contestant);
						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAll with values:");
					contestants.ForEach((x) => log.InfoFormat("{0}", x));
					return contestants;
				}
			}
		}

		public List<ContestantServiceDTO> FindAllByContestWithParticipationCount(int idContest)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAllByContest");
			IDbConnection con = DBUtils.GetConnection(props);
			List<ContestantServiceDTO> contestants = new List<ContestantServiceDTO>();
			using (var comm = con.CreateCommand())
			{
				//comm.CommandText = "select * from Contestants where id in (select idContestant from Participations where idContest=@id)";
				comm.CommandText = """
					select Contestants.*, count(Participations.id) as participationCount
					from Contestants
					         inner join Participations on Contestants.id = Participations.idContestant
					group by Contestants.id
					having Contestants.id in (select idContestant from Participations where idContest = ?)
					""";
				IDbDataParameter paramIdContest = comm.CreateParameter();
				paramIdContest.ParameterName = "@id";
				paramIdContest.Value = idContest;
				comm.Parameters.Add(paramIdContest);

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read() && !dataR.IsDBNull(0))
					{
						int idV = dataR.GetInt32(0);
						int age = dataR.GetInt32(1);
						string name = dataR.GetString(2);
						string cnp = dataR.GetString(3);
						int participationCount = dataR.GetInt32(4);

						Contestant contestant = new(name, age, cnp);
						contestant.Id = idV;

						contestants.Add(new ContestantServiceDTO(contestant, participationCount));
						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAllByContestWithParticipationCount with values:");
					contestants.ForEach((x) => log.InfoFormat("{0}", x));
					return contestants;
				}
			}
		}

		public List<Contestant> FindAllByGroup(int idGroup)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAllByGroup");
			IDbConnection con = DBUtils.GetConnection(props);
			List<Contestant> contestants = new List<Contestant>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select * from Contestants where age between (select MinimumAge from Groups where id=@id) and (select MaximumAge from Groups where id=@id)";
				IDbDataParameter paramId = comm.CreateParameter();
				paramId.ParameterName = "@id";
				paramId.Value = idGroup;
				comm.Parameters.Add(paramId);

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int age = dataR.GetInt32(1);
						string name = dataR.GetString(2);
						string cnp = dataR.GetString(3);

						Contestant contestant = new Contestant(name, age, cnp);
						contestant.Id = idV;

						contestants.Add(contestant);
						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAllByGroup with values:");
					contestants.ForEach((x) => log.InfoFormat("{0}", x)); ;
					return contestants;
				}
			}
		}

		public void Update(Contestant entity, int id)
		{
			throw new NotImplementedException();
		}

		void ICrudRepository<Contestant, int>.Add(Contestant entity)
		{
			throw new NotImplementedException();
		}
	}
}
