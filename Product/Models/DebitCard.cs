namespace Product.Models;

internal class DebitCard
{
    public DebitCard(string cardNumber, double balance)
    {
        CardNumber = cardNumber;
        Balance = balance;
    }

    public string CardNumber { get; set; }
    public double Balance { get; set; }
}

