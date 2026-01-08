using Microsoft.EntityFrameworkCore;
using CafePOS.Models;

namespace CafePOS.Data
{
    public class CafeDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Creează fișierul bazei de date în folderul proiectului
            options.UseSqlite("Data Source=cafe.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Îi spunem că 'Name' este identificatorul unic (cheia)
            // Astfel nu trebuie să adăugăm câmpul 'Id' în clasa ta originală
            modelBuilder.Entity<MenuItem>().HasKey(m => m.Name);
            modelBuilder.Entity<Employee>().HasKey(e => e.Pin);
        }
    }
}