using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public interface IContestantRepository : ICrudRepository<Contestant, int>
	{
		List<ContestantServiceDTO> FindAllByContestWithParticipationCount(int idContest);
		List<Contestant> FindAllByGroup(int idGroup);
		new Contestant Add(Contestant contestant);
	}
}
