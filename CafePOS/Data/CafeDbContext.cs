using Microsoft.EntityFrameworkCore;
using CafePOS.Models;
using CafePOS.Services;

namespace CafePOS.Data
{
    public class CafeDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=cafepos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Admin",
                    Role = "Admin",
                    Pin = PasswordHasher.Hash("0000")
                }
            );
        }
    }
}
