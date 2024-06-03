using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
	public class GroupDTO
	{
		public Group group;
		public GroupDTO() { }
		public GroupDTO(Group group)
		{
			this.group = group;
		}
		public GroupDTO(int minAge, int maxAge)
		{
			this.group = new Group(minAge, maxAge);
		}
		public GroupDTO(int id, int minAge, int maxAge)
		{
			this.group = new Group(minAge, maxAge)
			{
				Id = id
			};
		}
	}
}
