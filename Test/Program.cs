

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        var user2 = new User( 2, "John");
        var name = user2.Reverse();

        Console.WriteLine(name);
    }
}