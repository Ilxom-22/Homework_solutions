public class UzumPaymentProvider : IPaymentProvider
{
    private static UzumPaymentProvider _instance;
    private IDebitCard _bankAccount;
    public decimal TransferInterest { get; init; }



    private UzumPaymentProvider(IDebitCard card, decimal transferInterest)
    {
        if (card == null) 
            throw new ArgumentNullException(nameof(card));

        if (transferInterest < 0 && transferInterest > 50)
            throw new ArgumentOutOfRangeException(nameof(transferInterest), "Invalid transfer interest!");

        _bankAccount = card;
        TransferInterest = transferInterest;
    }



    public static UzumPaymentProvider GetInstance(IDebitCard card, decimal transferInterest)
    {
        if (_instance == null)
            _instance = new UzumPaymentProvider(card, transferInterest);

        return _instance;
    }



    public void Transfer(IDebitCard sourceCard, IDebitCard destinationCard, decimal amount)
    {
        if (sourceCard.Equals(destinationCard))
            throw new ArgumentException("The source card and destination card are the same!");

        if (amount <= 0)
            throw new ArgumentException("Invalid amount!");


        var interest = amount * TransferInterest / 100;

        if (sourceCard.Balance < amount + interest)
            throw new ArgumentException("Not enough money in the source card!");

        sourceCard.Balance -= amount + interest;
        _bankAccount.Balance += interest;
        destinationCard.Balance += amount;
    }
}