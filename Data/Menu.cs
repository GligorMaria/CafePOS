using System.Collections.Generic;
using System.Linq;

public class Menu
{
    private List<MenuItem> items = new List<MenuItem>();

      public Menu()
        {
            items.Add(new MenuItem("Latte", 12.5m, "Coffee"));
            items.Add(new MenuItem("Espresso", 8m, "Coffee"));
            items.Add(new MenuItem("Croissant", 7.5m, "Pastry"));
            items.Add(new MenuItem("Muffin", 8m, "Pastry"));
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
        return items.Where(i => i.Category == category).toList();
    }
}