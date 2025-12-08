using System.Collections.Generic;
using System.Linq;

public class Menu
{
    private List<MenuItem> items = new List<MenuItem>();

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