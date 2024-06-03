using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Contestant : IIdentifiable<int>
	{
		public Contestant() { }
		public Contestant(string name, int age, string cnp)
		{
			this.Name = name;
			this.Age = age;
			this.CNP = cnp;
		}
		public string Name { get; set; }
		public int Age { get; set; }
		public int Id { get; set; }

		public string CNP { get; set; }
		public override string ToString()
		{
			return $"Contestant: {Id}, {Name}, {Age}, {CNP}";
		}
	}
}
