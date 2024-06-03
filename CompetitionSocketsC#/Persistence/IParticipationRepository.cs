using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public interface IParticipationRepository : ICrudRepository<Participation, int>
	{
		int CountByContest(int id);
		List<Participation> FindAllByContestant(int idContestant);
	}
}
