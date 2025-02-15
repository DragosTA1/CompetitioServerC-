﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public interface IOperatorRepository : ICrudRepository<Operator, int>
	{
		Operator MatchByUserAndPassword(string user, string password);
	}
}
