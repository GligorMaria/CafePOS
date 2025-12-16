using System;
using CafePOS.Models;

namespace CafePOS.Services
{
    public class OrderManager
    {
        public event Action<MenuItem>? ItemAdded;
        public event Action<SaleTransaction>? SaleCompleted;

        private Order currentOrder = new Order();
        public Order CurrentOrder => currentOrder;

        public void addItem(MenuItem item)
        {
            currentOrder.AddItem(item);
            ItemAdded?.Invoke(item);
        }

        public void RemoveItem(MenuItem item)
        {
            currentOrder.RemoveItem(item);
        }

        public saleTransaction CompleteSale(decimal discount = 0, PaymentType paymentType = PaymentType.Cash, string employeeName = "Unknown")
        {
            var transaction = new SaleTranaction(currentOrder)
            {
                PaymentType = paymentType,
                employeeName = employeeName
            };
            transaction.ApplyDiscount(discount);
            SaleCompleted?.Invoke(transaction);
            CurrentOrder = new Order();
            return transaction;
        }

        public void ClearOrder() => currentOrder.ClearOrder();
    }
}