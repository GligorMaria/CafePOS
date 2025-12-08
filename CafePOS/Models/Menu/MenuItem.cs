namespace CafePOS.Models.Menu
{
    public class MenuItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Category { get; }

        public MenuItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
