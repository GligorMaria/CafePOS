using System.Collections.Generic;
using System.Linq;

namespace CafePOS.Models
{
    public class Order
    {
        private readonly List<MenuItem> _orderItems = new();

        public IReadOnlyList<MenuItem> Items => _orderItems;

        public void AddItem(MenuItem item)
        {
            _orderItems.Add(item);
        }

        public void RemoveItem(MenuItem item)
        {
            _orderItems.Remove(item);
        }

        public void ClearOrder()
        {
            _orderItems.Clear();
        }

        public decimal CalculateTotal()
        {
            return _orderItems.Sum(i => i.Price);
        }

        public string GetSummary()
        {
            if (_orderItems.Count == 0)
                return "Order is empty.";

            string summary = "Order Summary:\n";

            foreach (var item in _orderItems)
            {
                summary += $"- {item.Name} ({item.Price} RON)\n";
            }

            summary += $"--------------------\nTotal: {CalculateTotal()} RON";
            return summary;
        }
    }
}
