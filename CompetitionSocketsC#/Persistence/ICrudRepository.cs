using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public interface ICrudRepository<Entity, ID>
	{
		void Add(Entity entity);
		void Update(Entity entity, ID id);
		void Delete(Entity entity);
		Entity Find(ID id);
		List<Entity> FindAll();
	}
}
