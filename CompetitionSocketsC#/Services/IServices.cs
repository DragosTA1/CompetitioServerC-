using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
	public interface IServices
	{
		public List<ContestantServiceDTO> FindAllContestantsByContestWithParticipationCount(int idContest);
		public List<ContestServiceDTO> FindAllContestsByGroupWithParticipationCount(int idGroup);
		public List<Contest> FindAllContestsByGroup(int idGroup);
		public List<Group> FindAllGroups();
		public Group FindGroupByAge(int age);
		public void AddOperator(string username, string password, string email, string city);
		public Operator MatchByUserAndPassword(Operator op, IObserver client);
		public void AddParticipation(Contestant contestant, Contest contest);
		public void Logout(Operator op, IObserver client);
		Contestant AddContestant(string name, int age, string cnp);
	}
}
