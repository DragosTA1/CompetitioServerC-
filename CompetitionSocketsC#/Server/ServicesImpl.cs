using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Model;
using Persistence;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class ServicesImpl : IServices
	{
		private IOperatorRepository _operatorRepository;
		private IContestantRepository _contestantRepository;
		private IContestRepository _contestRepository;
		private IGroupRepository _groupRepository;
		private IParticipationRepository _participationRepository;
		private Dictionary<int, IObserver> loggedOperators;

		public ServicesImpl(IOperatorRepository operatorRepository, IContestantRepository contestantRepository, IContestRepository contestRepository, IGroupRepository groupRepository, IParticipationRepository participationRepository)
		{
			this._operatorRepository = operatorRepository;
			this._contestantRepository = contestantRepository;
			this._contestRepository = contestRepository;
			this._groupRepository = groupRepository;
			this._participationRepository = participationRepository;

			loggedOperators = new Dictionary<int, IObserver>();
		}
		public void AddOperator(string username, string password, string email, string city)
		{
			_operatorRepository.Add(new Operator(username, password, email, city));
		}

		public Contestant AddContestant(string name, int age, string cnp)
		{
			return _contestantRepository.Add(new Contestant(name, age, cnp));
		}

		public void AddParticipation(Contestant contestant, Contest contest)
		{
			Participation participation = new(contest, contestant, DateTime.UtcNow);
			_participationRepository.Add(participation);
			NotifyOperatorsLoggedIn(participation);
		}

		public List<ContestantServiceDTO> FindAllContestantsByContestWithParticipationCount(int idContest)
		{
			return _contestantRepository.FindAllByContestWithParticipationCount(idContest);
		}

		public List<Contest> FindAllContestsByGroup(int idGroup)
		{
			return _contestRepository.FindAllByGroup(idGroup);
		}

		public List<ContestServiceDTO> FindAllContestsByGroupWithParticipationCount(int idGroup)
		{
			List<ContestServiceDTO> result = new List<ContestServiceDTO>();
			var lst = _contestRepository.FindAllByGroup(idGroup);
			foreach (var contest in lst)
			{
				ContestServiceDTO contestDTO = new ContestServiceDTO(contest, _participationRepository.CountByContest(contest.Id));
				result.Add(contestDTO);
			}
			return result;
		}

		public List<Group> FindAllGroups()
		{
			return _groupRepository.FindAll();
		}

		public Group FindGroupByAge(int age)
		{
			return _groupRepository.FindGroupByAge(age);
		}

		public void Logout(Operator op, IObserver client)
		{
			if(loggedOperators.Remove(op.Id))
			{
				Console.WriteLine(loggedOperators.Count + " operators logged in.");
			} else
			{
				throw new CompetitionException("User " + op.Username + " is not logged in.");
			}

		}

		public Operator MatchByUserAndPassword(Operator op, IObserver client)
		{
			var foundOp = _operatorRepository.MatchByUserAndPassword(op.Username, op.Password);
			if(foundOp != null)
			{
				if(loggedOperators.TryGetValue(foundOp.Id, out _) == true)
				{
					throw new CompetitionException("Operator already logged in!");
				}
				loggedOperators.Add(foundOp.Id, client);
				Console.WriteLine(loggedOperators.Count + " operators logged in.");
			}
			return foundOp;
		}
		private void NotifyOperatorsLoggedIn(Participation participation)
		{
            foreach (IObserver operatorClient in loggedOperators.Values)
            {
                if(operatorClient != null)
				{
					Task.Run(() =>
					{
						try
						{
							operatorClient.ParticipationAdded(participation);
						} catch (CompetitionException ex) 
						{
							Console.WriteLine("Error notifying operator " + ex.Message);
						}
					});
				}
            }
        }
	}
}
