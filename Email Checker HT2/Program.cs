using System.Text.RegularExpressions;

namespace HT2
{
    class Program
    {
        static void Main(string[] args)
        {
            string email;
            int index = default;
            bool containsCapitalLetter = default;

            do
            {
                Console.Write("Input your email please: ");
                email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(email));

            string pattern = @"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$";
            var checker = new Regex(pattern);

            if (checker.IsMatch(email))
            {
                Console.WriteLine("Good");
            }
            else
            {
                string[] emailParts = email.Split("@");
                if (emailParts.Length != 2)
                    Console.WriteLine("Invalid email address.");
                else
                {
                    string mainPart = Regex.Replace(emailParts[0], @"[^a-zA-Z0-9.]", "");
                    string domainPart = "@" + emailParts[1];

                    string fixedEmail = mainPart + domainPart;

                    if (!checker.IsMatch(fixedEmail))
                        Console.WriteLine("Invalid email address");
                    else
                    {
                        Console.WriteLine("Emailda taqiqlangan simvollar qatnashishi mumkin emas.");
                        Console.WriteLine($"Example: {fixedEmail}");
                    }
                }
            }
        }
    }
}