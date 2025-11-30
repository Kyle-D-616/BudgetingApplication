using Microsoft.EntityFrameworkkCore;
using Spent.Common.Models;

namespace CategoryService.Data
{
	public class categoryDbContext : DbContext
	{
		public categoryDbContext(DbcontextOptions<categoryDbContext> options : base(options)) { }

		public DbSet<Category> Categories { get; set; }
		public Dbset<StandardCategory> StandardCategory { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

	modelBuildier.Entity<StandardCategory>().HasData(
			new StandardCategory { Id = Guid.NewGuid(), Name = "Groceries", DefaultAmount = 500, IconColor = "#10B981", SortOrder = 1 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Gas/Transportation", DefaultAmount = 400, IconColor = "#F59E0B", SortOrder = 2 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Utilities", DefaultAmount = 200, IconColor = "#3B82F6", SortOrder = 3 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Rent/Mortgage", DefaultAmount = 1500, IconColor = "#8B5CF6", SortOrder = 4 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Dining Out", DefaultAmount = 300, IconColor = "#EF4444", SortOrder = 5 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Entertainment", DefaultAmount = 150, IconColor = "#EC4899", SortOrder = 6 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Shopping", DefaultAmount = 200, IconColor = "#6366F1", SortOrder = 7 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Healthcare", DefaultAmount = 100, IconColor = "#14B8A6", SortOrder = 8 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Emergency Fund", DefaultAmount = 200, IconColor = "#F97316", SortOrder = 9 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Investments", DefaultAmount = 300, IconColor = "#059669", SortOrder = 10 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Subscriptions", DefaultAmount = 50, IconColor = "#0EA5E9", SortOrder = 11 },
			new StandardCategory { Id = Guid.NewGuid(), Name = "Miscellaneous", DefaultAmount = 100, IconColor = "#64748B", SortOrder = 12 }
            );		}
	}
}
