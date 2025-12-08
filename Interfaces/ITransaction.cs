public interface ITransaction
{
    decimal GetTotal();
    void ApplyDiscount(decimal percentage);
    string GetReceipt();
}
