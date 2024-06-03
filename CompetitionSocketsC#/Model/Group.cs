using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Group : IIdentifiable<int>
	{
		public Group() { }
		public Group(int min, int max) 
		{
			this.MinimumAge = min;
			this.MaximumAge = max;
		}
		public int Id { get; set; }
		public int MinimumAge { get; set; }
		public int MaximumAge { get; set; }
		public override string ToString()
		{
			return $"Group: {Id}, {MinimumAge}, {MaximumAge}";
		}
	}
}