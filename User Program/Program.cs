namespace UserProgram;

class Program
{
    static void Main(string[] args)
    {
        string name = GetInputValidated("Name");
        string lastName = GetInputValidated("Last Name");
        int age = GetAgeValidated();


       

        var user = new User(name, lastName, age);

        Console.WriteLine("User credentials: ");
        Console.WriteLine(user);
    }



    private static string GetInputValidated(string message)
    {
        string name = null;
        bool passed = false;
        do
        {
            try
            {
                Console.Write($"Input your {message}: ");
                string input = Console.ReadLine();
                name = input switch
                {
                    "" => throw new ArgumentNullException(),
                    var all when !all.isAllLetter() => throw new ArgumentOutOfRangeException(),
                    _ => input
                };
                passed = true;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"{message} field cannot be empty!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"{message} cannot contain numbers or characters!");
            }
        } while (!passed);

        return name;
    }



    private static int GetAgeValidated()
    {
        bool passed = false;
        int age = 0;

        Console.Write("Input your Age: ");

        do
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out age))
                    throw new ArgumentException();

                if (age < 4)
                    throw new ArgumentException();
                if (age > 100)
                    throw new ArgumentException();

                passed = true;
            }
            catch (ArgumentException)
            {
                Console.Write("Input valid age: ");
            }
        } while (!passed);

        return age;
    }
}
