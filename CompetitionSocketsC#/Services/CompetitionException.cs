using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class CompetitionException : Exception
	{
		public CompetitionException() { }
		public CompetitionException(string message) : base(message) { }
		public CompetitionException(string message,  Exception innerException) : base(message, innerException) { }
	}
}
