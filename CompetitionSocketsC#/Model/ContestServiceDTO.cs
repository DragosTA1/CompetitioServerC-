using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ContestServiceDTO
	{
		public int Id { get; set; }
		public int Type { get; set;  }
		public Group ParentGroup { get; set; }
		public int ParticipationCount { get; set; }
		public ContestServiceDTO() { }

		public ContestServiceDTO(Contest contest, int participationCount)
		{
			this.Id = contest.Id;
			this.Type = contest.Type;
			this.ParentGroup = contest.ParentGroup;

			this.ParticipationCount = participationCount;
		}
	}
}