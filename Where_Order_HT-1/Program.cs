bool IsPrime(int n)
{
    for (var i = 2; i < Math.Sqrt(n) + 1; i++)
        if (n % i == 0)
            return false;

    return true;
}


List<int> numbers = new List<int> { 37, 12, 5, 63, 29, 8, 11, 45, 17, 92, 
    19, 6, 31, 77, 23, 9, 41, 14, 2, 59, 13, 55, 7, 27, 89, 4, 67, 21, 3, 49 };

numbers.OrderDescending().Where(n => IsPrime(n)).ToList().ForEach(Console.WriteLine);