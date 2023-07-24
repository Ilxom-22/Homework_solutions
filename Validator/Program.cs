namespace Validation;

class Program
{
    static void Main(string[] args)
    {
        string name;
        string lastName;
        string age;
        string email;
        string phoneNumber;

        Console.Write("Input your name: ");
        name = Console.ReadLine();

        Console.Write("Input your lastName: ");
        lastName = Console.ReadLine();

        Console.Write("Input your age: ");
        age = Console.ReadLine();

        Console.Write("Input your email: ");
        email = Console.ReadLine();

        Console.Write("Input your phone number: ");
        phoneNumber = Console.ReadLine();

        Console.WriteLine("Validation statuses.");
        Console.WriteLine($"Name: {Validator.FirstName(name)}");
        Console.WriteLine($"Last Name: {Validator.LastName(lastName)}");
        Console.WriteLine($"Age: {Validator.Age(age)}");
        Console.WriteLine($"Email: {Validator.IsEmail(email)}");
        Console.WriteLine($"Phone number: {Validator.PhoneNumber(phoneNumber)}");
    }
}
