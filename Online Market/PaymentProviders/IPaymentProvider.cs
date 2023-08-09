public interface IPaymentProvider
{
    decimal TransferInterest { get; init; }

    void Transfer (IDebitCard sourceCard, IDebitCard destinationCard, decimal amount);
}