namespace CafePOS.Models
{
    public class Employee
    {
        public string Name { get; }
        public string Pin { get; }

        public Employee(string name, string pin)
        {
            Name = name;
            Pin = pin;
        }
    }
}