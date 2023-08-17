using Product.Models;

namespace Product.Services;

internal interface IPaymentService
{
    bool Checkout(double amount, DebitCard card);
}
