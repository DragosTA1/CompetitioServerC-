using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ContestantServiceDTO
	{
		public ContestantServiceDTO() { }
		public ContestantServiceDTO(Contestant contestant, int participationCount)
		{
			this.Id = contestant.Id;
			this.Name = contestant.Name;
			this.Age = contestant.Age;
			this.CNP = contestant.CNP;
			this.ParticipationCount = participationCount;
		}
		public int Id { get; set;  }
		public int Age { get; set; }
		public string Name { get; set; }
		public string CNP { get; set; }
		public int ParticipationCount { get; set; }
		public override string ToString()
		{
			string s = $"ContestantDTO - Id: {Id},  Age: {Age},Name: {Name}, CNP: {CNP}, ParticipationCount: {ParticipationCount}";
			return s ;
		}
	}
}
