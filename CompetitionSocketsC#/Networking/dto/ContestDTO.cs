using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
	public class ContestDTO
	{
		public ContestServiceDTO ContestServiceDTO { get; set; }
		public ContestDTO() { }
		public ContestDTO(ContestServiceDTO contestServiceDTO)
		{
			ContestServiceDTO = contestServiceDTO;
		}
		public ContestDTO(Contest c, int participationCount)
		{
			ContestServiceDTO contestServiceDTO = new ContestServiceDTO(c, participationCount);
			this.ContestServiceDTO = contestServiceDTO;
		}
	}
}
