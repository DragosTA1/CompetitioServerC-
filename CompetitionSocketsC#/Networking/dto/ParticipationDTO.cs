using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
	public class ParticipationDTO
	{
		public ParticipationDTO() { }
		public Contestant Contestant { get; set; }
		public Contest Contest { get; set; }
		public string DateString {  get; set; }
		public int Id { get; set; }
		public ParticipationDTO(Contestant contestant, Contest contest, DateTime date)
		{
			Contestant = contestant;
			Contest = contest;
			DateString = date.ToString();
			Id = 0;
		}

		public ParticipationDTO(Contestant contestant, Contest contest)
		{
			Contestant = contestant;
			Contest = contest;
			Id = 0;
			DateString = new DateTime().ToString();
		}
		public ParticipationDTO(int id, Contest contest, Contestant contestant, DateTime date)
		{
			Id = id;
			this.Contestant = contestant;
			this.Contest = contest;
			this.DateString = date.ToString();
		}
	}
}
