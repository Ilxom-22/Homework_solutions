using System.Numerics;


int number = 1000000000;

var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5));

BigInteger factorial = CalculateFactorial(number, cancellationToken.Token);

Console.WriteLine($"The factorial of {number} is: {factorial}");


static BigInteger CalculateFactorial(int n, CancellationToken cancellationToken = default)
{ 
    if (n < 0)
        throw new ArgumentException("Factorial is not defined for negative numbers.");

    if (n == 0 || n == 1)
        return 1;

    BigInteger result = 1;
    for (int i = 2; i <= n; i++)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();
        result *= i;
    }

    return result;
}
