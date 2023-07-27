namespace Password;

class Program
{
    static void Main(string[] args)
    {
        var passwordGenerator = new PasswordGenerator(true, 8, true);
        var password = passwordGenerator.GeneratePassword();
        Console.WriteLine(password);

        var securePasswordGenerator = new SecurePasswordGenerator(true, 12);
        var securePassword = securePasswordGenerator.GenerateSecurePassword(true);
        Console.WriteLine(securePassword);

        var uniquePasswordGenerator = new UniquePasswordGenerator(true, 6, true);
        var uniquePassword = uniquePasswordGenerator.GenerateUniquePassword();
        Console.WriteLine(uniquePassword);
    }
}