namespace Operator_overloading_Task;

internal class Money
{
    public Money(decimal amount, Currency currency, MoneyType type)
    {
        Amount = amount;
        Currency = currency;
        Type = type;
    }

    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
    public MoneyType Type { get; set; }


    // need to return new Money object.
    public static Money operator +(Money moneyA, Money moneyB)
    {
        var amountA = moneyA.Amount;
        var amountB = Convert(moneyB, moneyA.Currency);

        if (moneyA.Type == moneyB.Type)
            return new Money(amountA + amountB, moneyA.Currency, moneyA.Type);


        if (moneyA.Type == MoneyType.InBalance)
        {
            var amount = amountA - amountB;
            var type = MoneyType.InBalance;

            if (amount < 0)
            {
                amount = -amount;
                type = MoneyType.Loan;
            }
            return new Money(amount, moneyA.Currency, type);
        }

        var amount1 = amountB - amountA;
        var type1 = MoneyType.InBalance;
        if (amount1 < 0)
        {
            amount1 = -amount1;
            type1 = MoneyType.Loan;
        }
        return new Money(amount1, moneyA.Currency, type1);
    }


    private static decimal Convert(Money money, Currency targetCurrency)
    {
        Dictionary<string, decimal> rating = new Dictionary<string, decimal>()
        {
            { "UZS-USD", 12075m },
            { "UZS-RUB", 129.07m },
            { "USD-RUB", 0.011m }
        };

        if (money.Currency == targetCurrency)
            return money.Amount;

        if (targetCurrency == Currency.UZS)
        {
            if (money.Currency == Currency.USD)
                return money.Amount * rating["UZS-USD"];

            if (money.Currency == Currency.RUB)
                return money.Amount * rating["UZS-RUB"];
        }

        if (targetCurrency == Currency.USD)
        {
            if (money.Currency == Currency.UZS)
                return money.Amount / rating["UZS-USD"];

            if (money.Currency == Currency.RUB)
                return money.Amount * rating["USD-RUB"];

        }

        if (targetCurrency == Currency.RUB)
        {
            if (money.Currency == Currency.UZS)
                return money.Amount / rating["UZS-RUB"];

            if (money.Currency == Currency.USD)
                return money.Amount / rating["USD-RUB"];
        }

        return 0m;
    }

    public override string ToString()
    {
        return $"{Amount} - {Currency} - {Type}";
    }
}
