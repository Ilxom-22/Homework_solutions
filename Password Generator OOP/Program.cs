namespace Password;

class Program
{
    static void Main(string[] args)
    {
        bool numbersIncluded = Include("Include numbers");
        bool lettersIncluded = Include("Include letters");
        bool charactersIncluded = Include("Include characters");
        byte passwordLength;


        do
        {
            Console.Write("Input the password length: ");
        } while (!byte.TryParse(Console.ReadLine(), out passwordLength) || passwordLength < 4 || passwordLength > 16);

        var passwordGenerator = new PasswordGenerator(numbersIncluded, lettersIncluded, charactersIncluded, passwordLength);

        string password = passwordGenerator.GeneratePassword();
        Console.WriteLine(password);
    }



    private static bool Include(string question)
    {
        string template = $"{question} [Y/N]: ";
        string answer;

        do
        {
            Console.Write(template);
            answer = Console.ReadLine().ToLower().Trim();
        } while (answer != "y" && answer != "n");

        return answer == "y";
    }
}
