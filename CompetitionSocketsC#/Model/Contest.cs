using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Contest : IIdentifiable<int>
	{
		public Contest() { }
		public Contest(int type, Group parentGroup)
		{
			this.Type = type;
			this.ParentGroup = parentGroup;
		}
		public int Id { get; set; }
		public int Type { get; }
		public Group ParentGroup { get; set; }
		public override string ToString()
		{
			return $"Contest: {Id}, {Type}, {ParentGroup}";
		}
	}
}
