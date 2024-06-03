using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Operator : IIdentifiable<int>
	{
		public Operator() { }
		public Operator(string username, string password, string email, string city) 
		{
			Username = username;
			Password = password;
			Email = email;
			City = city;
		}
		public Operator(string username, string password)
		{
			Username = username;
			Password = password;
			Email = null;
			City = null;
		}
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string City { get; set; } 
		public int Id { get; set; }
		public override string ToString()
		{
			return $"Operator: {Id}, {Username}, {Password}, {Email}, {City}";
		}
	}
}
