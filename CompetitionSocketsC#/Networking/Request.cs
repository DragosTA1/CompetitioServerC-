using Model;
using Networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
	public class Request
	{
		public RequestType Type { get; set; } = 0;
		public OperatorDTO Operator { get; set; }
		public int GroupID { get; set; } = 0;
		public int ContestID { get; set; }
		public int GroupAge { get; set; }
		public ContestantDTO Contestant { get; set; }
		public ParticipationDTO Participation { get; set; }

		public override string ToString()
		{
			return "Type: " + Type.ToString() + "\nOperator: " + Operator + "\nGroupID: " + GroupID;
		}
	}
}
