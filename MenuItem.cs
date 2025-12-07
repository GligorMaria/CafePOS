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

    public override string ToString()
    {
        return $"{Name} - {Price} RON ({Category})";
    }
}