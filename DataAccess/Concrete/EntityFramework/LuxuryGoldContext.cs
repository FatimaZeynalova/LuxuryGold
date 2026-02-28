using Core.Entities.Concrete;
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
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OperationClaim> OperationClaim { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaim { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasMany(p => p.Images)
				.WithOne(i => i.Product)
				.HasForeignKey(i => i.ProductId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ProductImage>()
				.Property(i => i.Url)
				.IsRequired();
		}


	}
}
