using Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace UI
{
	public class ClientCtrl : IObserver
	{
		public event EventHandler<ObserverEventArgs> UpdateEvent;
		private IServices server;

		public ClientCtrl(IServices server)
		{
			this.server = server;
		}

		public void ParticipationAdded(Participation participation)
		{
			Console.WriteLine("Participation added " + participation);
			ObserverEventArgs obsArgs = new ObserverEventArgs(ObserverEvent.ParticipationAdded, participation);
			OnObsEvent(obsArgs);
		}

		protected virtual void OnObsEvent(ObserverEventArgs obsArgs)
		{
			if (obsArgs == null) return;
			UpdateEvent(this, obsArgs);
			Console.WriteLine("Update Event called");
		}

		public Operator Login(string username, string password)
		{
			return server.MatchByUserAndPassword(new Operator(username, password), this);
		}

		public List<Group> FindAllGroups()
		{
			return server.FindAllGroups();
		}
		public List<ContestServiceDTO> FindAllContests(int groupID)
		{
			return server.FindAllContestsByGroupWithParticipationCount(groupID);
		}

		public List<ContestantServiceDTO> FindAllContestants(int selectedContestIDValue)
		{
			return server.FindAllContestantsByContestWithParticipationCount(selectedContestIDValue);
		}

		public Group FindGroupByAge(int age)
		{
			return server.FindGroupByAge(age);
		}

		internal List<Contest>? FindAllContestsByGroup(int idGroup)
		{
			return server.FindAllContestsByGroup(idGroup);
		}

		internal Contestant AddContestant(string name, int age, string cnp)
		{
			return server.AddContestant(name, age, cnp);
		}

		public void AddParticipation(Contestant contestant, Contest contest)
		{
			server.AddParticipation(contestant, contest);
		}

		public void AddOperator(string user, string password, string email, string city)
		{
			server.AddOperator(user, password, email, city);
		}

		internal void Logout(Operator currentOperator)
		{
			server.Logout(currentOperator, this);
		}
	}
}