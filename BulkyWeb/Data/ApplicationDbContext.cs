using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Mohamed Category", DisplayOrder = 12 },
                new Category { CategoryId = 2, Name = "ahamed Category", DisplayOrder = 144 },
                new Category { CategoryId = 3, Name = "Mahamod Category", DisplayOrder = 15 }
                );
        }
    }
}
