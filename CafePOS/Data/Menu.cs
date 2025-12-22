using System.Collections.Generic;
using System.Linq;
using CafePOS.Models;

namespace CafePOS.Data
{
    public class Menu
    {
        private readonly List<MenuItem> items;

        public Menu()
        {
            items = new List<MenuItem>
            {
                // ☕ COFFEE
                new MenuItem("Espresso ☕", 8.00m, "Coffee"),
                new MenuItem("Double Espresso ☕☕", 11.00m, "Coffee"),
                new MenuItem("Latte 🤎", 12.50m, "Coffee"),
                new MenuItem("Vanilla Latte 🍦", 14.00m, "Coffee"),
                new MenuItem("Cappuccino 🤍", 12.00m, "Coffee"),
                new MenuItem("Caramel Macchiato 🍯", 15.00m, "Coffee"),
                new MenuItem("Mocha 🍫", 14.50m, "Coffee"),

                // 🧋 COLD DRINKS
                new MenuItem("Iced Latte 🧊", 13.00m, "Cold Drinks"),
                new MenuItem("Iced Mocha ❄️", 14.50m, "Cold Drinks"),
                new MenuItem("Cold Brew 🌿", 13.50m, "Cold Drinks"),
                new MenuItem("Matcha Latte 🍵", 15.00m, "Cold Drinks"),

                // 🥐 PASTRIES
                new MenuItem("Butter Croissant 🥐", 7.50m, "Pastry"),
                new MenuItem("Chocolate Croissant 🍫", 9.00m, "Pastry"),
                new MenuItem("Almond Croissant 🌰", 9.50m, "Pastry"),
                new MenuItem("Cinnamon Roll 🤎", 10.00m, "Pastry"),

                // 🧁 SWEETS
                new MenuItem("Blueberry Muffin 🫐", 8.00m, "Sweets"),
                new MenuItem("Chocolate Muffin 🍫", 8.50m, "Sweets"),
                new MenuItem("Cupcake 🧁", 9.00m, "Sweets"),
                new MenuItem("Cheesecake 🍰", 12.00m, "Sweets"),

                // 🥪 SNACKS
                new MenuItem("Avocado Toast 🥑", 14.00m, "Snacks"),
                new MenuItem("Grilled Cheese 🧀", 13.00m, "Snacks"),
                new MenuItem("Ham & Cheese Panini 🥪", 15.00m, "Snacks")
            };
        }

        public void AddItem(MenuItem item)
        {
            items.Add(item);
        }

        public List<MenuItem> GetAllItems()
        {
            return items;
        }

        public List<MenuItem> GetItemsByCategory(string category)
        {
            return items
                .Where(i => i.Category == category)
                .ToList();
        }
    }
}
