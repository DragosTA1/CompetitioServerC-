using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public interface IContestRepository : ICrudRepository<Contest, int>
	{
		List<Contest> FindAllByContestant(int idContestant);
		List<Contest> FindAllByGroup(int idGroup);
	}
}
