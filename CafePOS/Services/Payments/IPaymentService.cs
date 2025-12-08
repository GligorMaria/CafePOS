namespace CafePOS.Services.Payments
{
    public interface IPaymentService
    {
        bool ProcessPayment(decimal amount);
    }
}
