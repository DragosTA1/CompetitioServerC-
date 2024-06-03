using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Participation : IIdentifiable<int>
	{
		public Participation() { }
		public Participation(Contest contest, Contestant contestant, DateTime date)
		{
			this.Contestant = contestant;
			this.Contest = contest;
			this.Date = date;
		}
		public int Id { get; set; }
		public Contestant Contestant { get; set; }
		public Contest Contest{ get; set; }
		public DateTime Date { get; }
		public override string ToString()
		{
			return $"Participation: {Id}, {Contestant}, {Contest}, {Date}";
		}
	}
}