using Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence
{
	public class ParticipationRepository : IParticipationRepository
	{
		private static readonly ILog log = LogManager.GetLogger("ParticipationRepository");
		readonly IDictionary<string, string> props;
		IDbConnection? con;
		public ParticipationRepository(IDictionary<string, string> props) {
			log.Info("Creating ParticipationRepository ");
			this.props = props;
		}

		public void Add(Participation participation)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering Add with value {0}", participation);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "insert into Participations(idContestant, idContest, date) values (@idContestant, @idContest, @date)";
				var paramIdContestant = comm.CreateParameter();
				paramIdContestant.ParameterName = "@idContestant";
				paramIdContestant.Value = participation.Contestant.Id;
				comm.Parameters.Add(paramIdContestant);

				var paramIdContest = comm.CreateParameter();
				paramIdContest.ParameterName = "@idContest";
				paramIdContest.Value = participation.Contest.Id;
				comm.Parameters.Add(paramIdContest);

				var paramDate = comm.CreateParameter();
				paramDate.ParameterName = "@date";
				paramDate.Value = GetUnixTimeStampFromDateTime(participation.Date);
				comm.Parameters.Add(paramDate);

				var result = comm.ExecuteNonQuery();
				if (result == 0)
					throw new Exception("No participation added !");
				log.InfoFormat("Added!");
			}
			log.InfoFormat("Exiting Add!");
		}

		public void Delete(Participation entity)
		{
			throw new NotImplementedException();
		}

		public Participation Find(int id)
		{
			throw new NotImplementedException();
		}

		public List<Participation> FindAll()
		{
			throw new NotImplementedException();
		}

		public List<Participation> FindAllByContestant(int idContestant)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAllByContestant with value {0}", idContestant);
			IDbConnection con = DBUtils.GetConnection(props);
			List<Participation> participations = new List<Participation>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select Participations.*, Contestants.age, Contestants.name, Contestants.CNP, Contests.type, Contests.idParentGroup, Groups.minimumAge, Groups.maximumAge from Participations inner join Contestants on Participations.idContestant = Contestants.id inner join Contests on Participations.idContest = Contests.id inner join Groups on Groups.id = Contests.idParentGroup where Participations.idContestant=@idContestant";

				IDbDataParameter paramIdContestant = comm.CreateParameter();
				paramIdContestant.ParameterName = "@idContestant";
				paramIdContestant.Value = idContestant;
				comm.Parameters.Add(paramIdContestant);

				using(var dataR = comm.ExecuteReader())
				{
					while(dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int idContest = dataR.GetInt32(2);
						var dateRaw = dataR.GetInt64(3);
						int age = dataR.GetInt32(4);
						var name = dataR.GetString(5);
						var CNP = dataR.GetString(6);
						var type = dataR.GetInt32(7);
						var idParent = dataR.GetInt32(8);
						var minAge = dataR.GetInt32(9);
						var maxAge = dataR.GetInt32(10);


						Contestant contestant = new Contestant(name, age, CNP);
						contestant.Id = idContestant;

						Group group = new Group(minAge, maxAge);
						group.Id = idParent;

						Contest contest = new Contest(type, group);
						contest.Id = idContestant;
						DateTime dateTime = GetDateTimeFromUnixTimeStamp(dateRaw);

						Participation participation = new Participation(contest, contestant, dateTime) { Id = idV };

						participations.Add(participation);

						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAllByContestant with values:");
					participations.ForEach((x) => log.InfoFormat("{0}", x));
					return participations;
				}
			}
		}

		private static DateTime GetDateTimeFromUnixTimeStamp(long dateRaw)
		{
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(dateRaw);
			DateTime dateTime = dateTimeOffset.UtcDateTime;
			return dateTime;
		}
		private static long GetUnixTimeStampFromDateTime(DateTime dateTime)
		{
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
			return dateTimeOffset.ToUnixTimeMilliseconds();
		}

		public void Update(Participation entity, int id)
		{
			throw new NotImplementedException();
		}

		public int CountByContest(int id)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering CountByContest with Contest Id {0}", id);
			IDbConnection con = DBUtils.GetConnection(props);
			using(var comm = con.CreateCommand())
			{
				comm.CommandText = "select count(*) as count from Participations where idContest=@id";

				IDbDataParameter paramIdContest= comm.CreateParameter();
				paramIdContest.ParameterName = "@id";
				paramIdContest.Value = id;
				comm.Parameters.Add(paramIdContest);

				using(var dataR = comm.ExecuteReader())
				{
					dataR.Read();

					int cnt = dataR.GetInt32(0);
					log.InfoFormat("Gotten!");
					return cnt;
				}
			}
		}
	}
}
