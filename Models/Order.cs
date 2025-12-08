using System.Collections.Generic;
using System.Linq;

namespace CafePOS.Models
{
    public class Order
    {
        private List<MenuItem> orderItems = new List<MenuItem>();

        public void AddItem(MenuItem item)
        {
            orderItems.Add(item);
        }

        public List<MenuItem> GetItems()
        {
            return orderItems;
        }

        public decimal CalculateTotal()
        {
            return orderItems.Sum(i => i.Price);
        }

        public string GetSummary()
        {
            string summary = "Order Summary:\n";
            foreach (var item in orderItems)
            {
                summary += $"Total: {CalculateTotal()} RON\n";
                return summary;
            }
        }

        public void RemoveItem(MenuItem item) => orderItems.Remove(item);
        public void ClearOrder()
        {
            orderItems.Clear();
        }


    }
}