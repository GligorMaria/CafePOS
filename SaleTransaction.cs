using System;

public class SaleTransaction : ITransaction
{
    private Order order;
    private decimal discountPercentage = 0;

    public SaleTransaction(Order order)
    {
        this.order = order;
    }

    public void ApplyDiscount(decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentException("Discount must be between 0 and 100%");
        discountPercentage = percentage;
    }

    public decimal GetTotal()
    {
        decimal total = order.CalculateTotal();
        decimal discountAmount = total * (discountPercentage / 100m);
        return total - discountAmount;
    }

    public string GetReceipt()
    {
        string receipt = order.GetSummary();

        if(discountPercentage>0)
        {
            receipt += $"Discount: {discountPercentage}%\n";
            receipt += $"Total After Discount: {GetTotal()} RON\n";
        }
        else
        {
            receipt += $"Final Total: {GetTotal()} RON\n";
        }

        receipt += $"Time: {DateTime.Now}\n";
        return receipt;
    }
    
}