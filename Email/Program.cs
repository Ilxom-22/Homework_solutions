namespace Email;

class Program
{
    static void Main(string[] args)
    {
        var validEmail = new Email("james@gmail.com", "ilxom@gmail.com", "The Latest Commit issue", "...");
        Console.WriteLine(validEmail);
        Console.WriteLine();


        var invalidEmail = new Email("jamesgmail.com", "ilxom@gmailcom", "123", "...");
        Console.WriteLine(invalidEmail);
    }
}
