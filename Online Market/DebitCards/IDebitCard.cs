public interface IDebitCard
{
    string CardNumber { get; set; }
    string BankName { get; set; }
    decimal Balance { get; set; }
}