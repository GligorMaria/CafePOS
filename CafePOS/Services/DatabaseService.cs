using CafePOS.Data;
using CafePOS.Models;
using System.Linq;
using System.Collections.Generic;

namespace CafePOS.Services
{
    public class DatabaseService
    {
        public void Initialize()
        {
            using (var db = new CafeDbContext())
            {
                // Creează baza de date automat dacă nu există (fără migrări!)
                db.Database.EnsureCreated();

                // Dacă tabela de produse e goală, o populăm cu datele tale originale
                if (!db.MenuItems.Any())
                {
                    var originalMenu = new CafePOS.Data.Menu(); 
                    db.MenuItems.AddRange(originalMenu.GetAllItems());
                    db.SaveChanges();
                }
            }
        }

        public List<MenuItem> LoadMenu()
        {
            using (var db = new CafeDbContext())
            {
                return db.MenuItems.ToList();
            }
        }
    }
}