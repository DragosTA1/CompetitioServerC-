using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class EFContext : DbContext
	{
		public DbSet<Operator> Operators { get; set; }
		public string DbPath { get; set; }
		public EFContext()
		{
			DbPath = ConfigurationManager.AppSettings["DbPath"];
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite($"Data Source={DbPath}");
		}
	}
}
