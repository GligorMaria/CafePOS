using System;
using CafePOS.Models;
using CafePOS.Models.Enums; // <--- ADD THIS LINE

namespace CafePOS.Services
{
    public class OrderManager
    {
        public event Action<MenuItem>? ItemAdded;
        public event Action<SaleTransaction>? SaleCompleted;

        private Order _currentOrder = new Order();
        
        public Order CurrentOrder 
        { 
            get => _currentOrder; 
            private set => _currentOrder = value; 
        }

        public void addItem(MenuItem item)
        {
            _currentOrder.AddItem(item);
            ItemAdded?.Invoke(item);
        }

        public void RemoveItem(MenuItem item)
        {
            _currentOrder.RemoveItem(item);
        }

        // Now that the 'using' is added, PaymentType will be recognized
        public SaleTransaction CompleteSale(PaymentType paymentType, decimal discount = 0)
        {
            var transaction = new SaleTransaction(_currentOrder, paymentType);
            
            transaction.ApplyDiscount(discount);
            SaleCompleted?.Invoke(transaction);
            
            CurrentOrder = new Order(); 
            
            return transaction;
        }

        public void ClearOrder() => _currentOrder.ClearOrder();
    }
}