namespace CafePOS.Interfaces
{
    public interface ITransaction
    {
        decimal GetTotal();
        string GetReceipt();
    }
}
