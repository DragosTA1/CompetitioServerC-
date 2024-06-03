using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
	public class ContestantDTO
	{
		public ContestantServiceDTO ContestantServiceDTO { get; set; }
		public ContestantDTO() { }
		public ContestantDTO(ContestantServiceDTO contestantServiceDTO)
		{
			ContestantServiceDTO = contestantServiceDTO;
		}

		public ContestantDTO(Contestant c, int participationCount)
		{
			ContestantServiceDTO = new(c, 0);
		}
	}
}
