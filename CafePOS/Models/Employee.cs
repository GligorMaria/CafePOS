namespace CafePOS.Models
{
    public class Employee
    {
        // EF are nevoie de set; pentru a încărca datele din tabel
        public string Name { get; set; } = string.Empty;
        public string Pin { get; set; } = string.Empty;

        // 1. Constructor obligatoriu pentru Entity Framework
        public Employee()
        {
        }

        // 2. Constructorul tău original (rămâne pentru logica aplicației)
        public Employee(string name, string pin)
        {
            Name = name;
            Pin = pin;
        }
    }
}