using System.Text.RegularExpressions;

namespace Email;

class Program
{
    static void Main(string[] args)
    {
        string[] email = new string[5];
        string pattern = @"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$";
        var checker = new Regex(pattern);

        for (var i = 0; i < 5; i++)
        {
            Console.Write("Input an email address: ");
            email[i] = Console.ReadLine();
        }

        Console.WriteLine();
        foreach (var i in email)
            if (checker.IsMatch(i.Trim()))
                Console.WriteLine($"{i} - Valid!");
            else
                Console.WriteLine($"{i} - Invalid!");
    }
}