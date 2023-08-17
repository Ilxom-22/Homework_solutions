using Product.Models;

namespace Product.Services;

internal class PaymentService : IPaymentService
{
    public bool Checkout(double amount, DebitCard card)
    {
        if (card.Balance < amount)
            return false;

        card.Balance -= amount;
        return true;
    }
}
