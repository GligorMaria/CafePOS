namespace CafePOS.Models
{
    public class MenuItem
    {
        // EF are nevoie de set; pentru a putea popula obiectul din baza de date
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;

        // 1. Constructorul gol - OBLIGATORIU pentru EF
        public MenuItem() { }

        // 2. Constructorul cu parametri
        // Asigură-te că numele parametrilor (name, price, category) 
        // corespund proprietăților de mai sus
        public MenuItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}