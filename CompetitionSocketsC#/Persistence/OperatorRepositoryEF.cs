using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class OperatorRepositoryEF : IOperatorRepository
	{
		private readonly EFContext _context;
		public OperatorRepositoryEF(EFContext context)
		{
			_context = context;
		}
		public void Add(Operator entity)
		{
			_context.Operators.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(Operator entity)
		{
			throw new NotImplementedException();
		}

		public Operator Find(int id)
		{
			throw new NotImplementedException();
		}

		public List<Operator> FindAll()
		{
			throw new NotImplementedException();
		}

		public Operator? MatchByUserAndPassword(string user, string password)
		{
			return _context.Operators.FirstOrDefault(e => e.Username == user && e.Password == password);
		}

		public void Update(Operator entity, int id)
		{
			throw new NotImplementedException();
		}
	}
}
