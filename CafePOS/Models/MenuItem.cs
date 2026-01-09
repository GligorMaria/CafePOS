namespace CafePOS.Models
{
    public class MenuItem
    {
        // EF Core NEEDS a primary key
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;

        // Constructor gol - obligatoriu pentru EF
        public MenuItem() { }

        // Constructor cu parametri
        public MenuItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
