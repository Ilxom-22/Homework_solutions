public class KaptalUzCard : IDebitCard
{
    public string CardNumber { get; set; }
    public string BankName { get; set; }
    public decimal Balance { get; set; }



    public KaptalUzCard(string cardNumber, string bankName)
    {
        if (!DebitCardValidator.ValidCardNumber(cardNumber))
            throw new ArgumentException("Invalid card number!");

        if (!DebitCardValidator.ValidBankName(bankName))
            throw new ArgumentException("Invalid Bank name!");

        CardNumber = cardNumber;
        BankName = bankName;
        Balance = 0;
    }



    public override int GetHashCode()
    {
        return CardNumber.GetHashCode();
    }


    public override bool Equals(object? obj)
    {
        if (obj != null && obj is IDebitCard)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}