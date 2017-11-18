using Main.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Main.DAL
{
	public class OrderSystemContext : DbContext
	{
		public OrderSystemContext() : base("OrderSystemContext") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}