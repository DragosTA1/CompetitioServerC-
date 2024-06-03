using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.dto
{
	public class OperatorDTO
	{
		public Operator Operator { get; set; }
		public OperatorDTO()
		{
			Operator = new Operator();
		}
		public OperatorDTO(Operator @operator)
		{
			Operator = @operator;
		}
		public OperatorDTO(int id, string username, string email, string password, string city)
		{
			this.Operator.Id = id;
			this.Operator.Username = username;
			this.Operator.Email = email;
			this.Operator.Password = password;
			this.Operator.City = city;
		}
	}
}
