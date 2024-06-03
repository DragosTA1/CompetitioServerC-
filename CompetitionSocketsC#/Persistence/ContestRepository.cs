using log4net;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class ContestRepository : IContestRepository
	{
		private static readonly ILog log = LogManager.GetLogger("ContestRepository");
		readonly IDictionary<string, string> props;
		IDbConnection? con;
		public ContestRepository(IDictionary<string, string> props)
		{
			log.Info("Creating ContestRepository");
			this.props = props;
		}

		public void Add(Contest entity)
		{
			throw new NotImplementedException();
		}
		public void Delete(Contest entity)
		{
			throw new NotImplementedException();
		}
		public Contest Find(int id)
		{
			throw new NotImplementedException();
		}

		public List<Contest> FindAll()
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAll");
			IDbConnection con = DBUtils.GetConnection(props);
			List<Contest> contests = new List<Contest>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select Contests.*, Groups.minimumAge, Groups.maximumAge from Contests inner join Groups on Contests.idParentGroup = Groups.id";

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int type = dataR.GetInt32(1);
						int idParentGroup = dataR.GetInt32(2);
						int minAge = dataR.GetInt32(3);
						int maxAge = dataR.GetInt32(4);

						Group group = new Group(minAge, maxAge);
						group.Id = idParentGroup;

						Contest contest = new Contest(type, group);
						contest.Id = idV;

						contests.Add(contest);

						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAll with values:");
					contests.ForEach((x) => log.InfoFormat("{0}", x));
					return contests;
				}
			}
		}

		public List<Contest> FindAllByContestant(int idContestant)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAllByContestant");
			IDbConnection con = DBUtils.GetConnection(props);
			List<Contest> contests = new List<Contest>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select Contests.*, Groups.minimumAge, Groups.maximumAge from Contests inner join Participations on Contests.id = Participations.idContest inner join Groups on Groups.id = Contests.idParentGroup where Participations.idContestant = @idContestant";
				IDbDataParameter paramIdContestant = comm.CreateParameter();
				paramIdContestant.ParameterName = "@idContestant";
				paramIdContestant.Value = idContestant;
				comm.Parameters.Add(paramIdContestant);
				
				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int type = dataR.GetInt32(1);
						int idParentGroup = dataR.GetInt32(2);
						int minAge = dataR.GetInt32(3);
						int maxAge = dataR.GetInt32(4);

						Group group = new Group(minAge, maxAge);
						group.Id = idParentGroup;

						Contest contest = new Contest(type, group);
						contest.Id = idV;

						contests.Add(contest);

						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAllByContestant with values:");
					contests.ForEach((x)=>log.InfoFormat("{0}", x));
					return contests;
				}
			}
		}

		public List<Contest> FindAllByGroup(int idGroup)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAllByGroup");
			IDbConnection con = DBUtils.GetConnection(props);
			List<Contest> contests = new List<Contest>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select Contests.*, Groups.minimumAge, Groups.maximumAge from Contests inner join Groups on Contests.idParentGroup = Groups.id where idParentGroup = @idGroup";
				IDbDataParameter paramIdGroup = comm.CreateParameter();
				paramIdGroup.ParameterName = "@idGroup";
				paramIdGroup.Value = idGroup;
				comm.Parameters.Add(paramIdGroup);

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int type = dataR.GetInt32(1);
						int idParentGroup = dataR.GetInt32(2);
						int minAge = dataR.GetInt32(3);
						int maxAge = dataR.GetInt32(4);

						Group group = new Group(minAge, maxAge);
						group.Id = idParentGroup;

						Contest contest = new Contest(type, group);
						contest.Id = idV;

						contests.Add(contest);

						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAllByGroup with values:");
					contests.ForEach((x) => log.InfoFormat("{0}", x));
					return contests;
				}
			}
		}

		public void Update(Contest entity, int id)
		{
			throw new NotImplementedException();
		}

		Contest ICrudRepository<Contest, int>.Find(int id)
		{
			throw new NotImplementedException();
		}

		List<Contest> ICrudRepository<Contest, int>.FindAll()
		{
			throw new NotImplementedException();
		}

		List<Contest> IContestRepository.FindAllByContestant(int idContestant)
		{
			throw new NotImplementedException();
		}

	}
}
