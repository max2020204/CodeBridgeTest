using CodeBridgeTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dog>().HasIndex(x => x.Name).IsUnique(true);
            modelBuilder.Entity<Dog>().HasData(
                new Dog
                {
                    Id = 1,
                    Name = "Neo",
                    Color = "red & amber",
                    TailLength = 22f,
                    Weight = 32f
                },
                new Dog
                {
                    Id = 2,
                    Name = "Jessy",
                    Color = "black & white",
                    TailLength = 7f,
                    Weight = 14
                });
        }
    }
}
