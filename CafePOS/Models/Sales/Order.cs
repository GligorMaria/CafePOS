using System.Collections.Generic;

namespace CafePOS.Models.Sales
{
    public class Order
    {
        public List<MenuItem> Items { get; } = new();
        public decimal Total => Items.Sum(i => i.Price);
    }
}
