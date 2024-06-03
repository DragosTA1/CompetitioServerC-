using Model;
using Networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
	public class Response
	{
		public List<GroupDTO> Groups;

		public ResponseType Type { get; set; }
		public OperatorDTO Operator { get; set; }
		public string ErrorMessage { get; set; }
		public List<ContestDTO> Contests { get; set; }
		public List<ContestantDTO> Contestants { get; set; }
		public ContestantDTO Contestant { get; set; }
		public ParticipationDTO Participation { get; set; }

		public override string ToString()
		{
			return "Type: " + Type.ToString() 
				+ "Operator: " + Operator 
				+ "Groups: " + Groups
				+ "Contests: " + Contests
				+ "ErrMsg: " + ErrorMessage;
		}
	}
}
