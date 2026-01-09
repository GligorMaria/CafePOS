using CafePOS.Data;
using CafePOS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CafePOS.Services
{
    public class DatabaseService
    {
        public void Initialize()
        {
            using var db = new CafeDbContext();

            if (!db.MenuItems.Any())
            {
                var originalMenu = new CafePOS.Data.Menu();
                db.MenuItems.AddRange(originalMenu.GetAllItems());
                db.SaveChanges();
            }
        }

        public List<MenuItem> LoadMenu()
        {
            using var db = new CafeDbContext();
            return db.MenuItems.ToList();
        }
    }
}
