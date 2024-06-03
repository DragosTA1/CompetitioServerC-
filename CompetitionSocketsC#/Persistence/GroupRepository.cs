using Model;
using log4net;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class GroupRepository : IGroupRepository
	{
		private static readonly ILog log = LogManager.GetLogger("GroupRepository");
		readonly IDictionary<string, string> props;
		IDbConnection? con;
		public GroupRepository(IDictionary<string, string> props)
		{
			log.Info("Creating GroupRepository ");
			this.props = props;
		}

		public void Add(Group entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Group entity)
		{
			throw new NotImplementedException();
		}

		public Group Find(int id)
		{
			throw new NotImplementedException();
		}

		public List<Model.Group> FindAll()
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindAll");
			IDbConnection con = DBUtils.GetConnection(props);
			List<Model.Group> groups = new List<Model.Group>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select * from Groups";

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int minAge = dataR.GetInt32(1);
						int maxAge = dataR.GetInt32(2);

						Group group = new Group(minAge, maxAge);
						group.Id = idV;

						groups.Add(group);

						log.InfoFormat("Found!");
					}

					log.InfoFormat("Exiting FindAll with values:");
					groups.ForEach((x) => log.InfoFormat("{0}", x));
					return groups;
				}
			}
		}

		public Group FindGroupByAge(int age)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindGroupByAge with value {0}", age);
			IDbConnection con = DBUtils.GetConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select * from Groups where minimumAge <= @age and maximumAge >= @age";
				IDbDataParameter paramAge = comm.CreateParameter();
				paramAge.ParameterName = "@age";
				paramAge.Value = age;
				comm.Parameters.Add(paramAge);

				using (var dataR = comm.ExecuteReader())
				{
					if (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int minAge = dataR.GetInt32(1);
						int maxAge = dataR.GetInt32(2);

						Group group = new Group(minAge, maxAge);
						group.Id = idV;
						log.InfoFormat("Found!");

						log.InfoFormat("Exiting FindGroupByAge with value {0}", group);
						return group;
					}

				}
			}

			log.InfoFormat("Exiting FindGroupByAge with value {0}", null);
			return null;
		}

		public Group FindGroupByContest(int idContest)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindGroupByContest with value {0}", idContest);
			IDbConnection con = DBUtils.GetConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select Groups.* from Groups inner join Contests on Groups.id = Contests.idParentGroup where Contests.id = @IdContest";
				IDbDataParameter paramIdContest = comm.CreateParameter();
				paramIdContest.ParameterName = "@IdContest";
				paramIdContest.Value = idContest;
				comm.Parameters.Add(paramIdContest);

				using (var dataR = comm.ExecuteReader())
				{
					if (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int minAge = dataR.GetInt32(1);
						int maxAge = dataR.GetInt32(2);

						Group group = new Group(minAge, maxAge);
						group.Id = idV;
						log.InfoFormat("Found!");

						log.InfoFormat("Exiting FindGroupByContest with value {0}", group);
						return group;
					}

				}
			}

			log.InfoFormat("Exiting FindGroupByContest with value {0}", null);
			return null;
		}

		public Group FindGroupByParticipation(int idParticipation)
		{
			this.con = DBUtils.GetConnection(props);
			log.InfoFormat("Entering FindGroupByParticipation with value {0}", idParticipation);
			IDbConnection con = DBUtils.GetConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select Groups.* from Groups inner join Contests on Groups.id = Contests.idParentGroup inner join Participations on Contests.id = Participations.idContest where Participations.id = @id";
				IDbDataParameter paramIdParticipation = comm.CreateParameter();
				paramIdParticipation.ParameterName = "@id";
				paramIdParticipation.Value = idParticipation;
				comm.Parameters.Add(paramIdParticipation);

				using (var dataR = comm.ExecuteReader())
				{
					if (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						int minAge = dataR.GetInt32(1);
						int maxAge = dataR.GetInt32(2);

						Group group = new Group(minAge, maxAge);
						group.Id = idV;
						log.InfoFormat("Found!");

						log.InfoFormat("Exiting FindGroupByParticipation with value {0}", group);
						return group;
					}

				}
			}

			log.InfoFormat("Exiting FindGroupByParticipation with value {0}", null);
			return null;
		}

		public void Update(Group entity, int id)
		{
			throw new NotImplementedException();
		}
	}
}
