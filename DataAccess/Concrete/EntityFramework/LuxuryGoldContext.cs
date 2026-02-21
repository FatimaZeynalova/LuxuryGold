using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class LuxuryGoldContext : DbContext
	{
		override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=WINDOWS-4H8TAO8\SQLEXPRESS;Database=LuxuryGold;TrustServerCertificate=True;Trusted_Connection=true");

		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

	}
}
