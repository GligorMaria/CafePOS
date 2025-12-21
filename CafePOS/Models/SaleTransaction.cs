using System;
using CafePOS.Interfaces;
using CafePOS.Models.Enums;

namespace CafePOS.Models
{
    public class SaleTransaction : ITransaction
    {
        private readonly Order _order;
        private decimal _discountPercentage;

        public PaymentType PaymentType { get; }
        public DateTime Timestamp { get; }

        public SaleTransaction(Order order, PaymentType paymentType)
        {
            _order = order;
            PaymentType = paymentType;
            Timestamp = DateTime.Now;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Discount must be between 0 and 100%");

            _discountPercentage = percentage;
        }

        public decimal GetTotal()
        {
            decimal total = _order.CalculateTotal();
            decimal discountAmount = total * (_discountPercentage / 100m);
            return total - discountAmount;
        }

        public string GetReceipt()
        {
            string receipt = _order.GetSummary() + Environment.NewLine;

            if (_discountPercentage > 0)
            {
                receipt += $"Discount: {_discountPercentage}%{Environment.NewLine}";
            }

            receipt += $"Payment: {PaymentType}{Environment.NewLine}";
            receipt += $"Final Total: {GetTotal()} RON{Environment.NewLine}";
            receipt += $"Time: {Timestamp}{Environment.NewLine}";

            return receipt;
        }
    }
}
