using Operator_overloading_Task;

var money1 = new Money(50000, Currency.UZS, MoneyType.InBalance);
var money2 = new Money(10000, Currency.UZS, MoneyType.Loan);

Console.WriteLine(money1 + money2);

var uzs = new Money(50000, Currency.UZS, MoneyType.Loan);
var usd = new Money(15, Currency.USD, MoneyType.InBalance);

Console.WriteLine(usd + uzs);