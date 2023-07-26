namespace UserType;

class Program
{
    static void Main(string[] args)
    {
        var user1 = new User { Name = "James", LastName = "Carter", Surname = "Smith" };
        var user2 = new User { Name = "Carter", LastName = "Smith", Surname = "James" };
        var user3 = new User { Name = "James", LastName = "Carter", Surname = "Smith" };
        


        Console.WriteLine($"Full Name of the user 1: {user1._fullName}");
        Console.WriteLine();
        Console.WriteLine($"Full Name of the user 2: {user2._fullName}");
        Console.WriteLine($"Full Name of the user 3: {user3._fullName}");
        Console.WriteLine();

        Console.WriteLine($"Equality of the user 1 and user 2: {user1.Equals(user2)}");
        Console.WriteLine($"Equality of the user 2 and user 3: {user2.Equals(user3)}");
        Console.WriteLine($"Equality of the user 1 and user 3: {user1.Equals(user3)}");

        Console.WriteLine();
        user1.Name = "Lily";
        Console.WriteLine($"Full Name of the user 1 after changing its name: {user1._fullName}");
    }
}