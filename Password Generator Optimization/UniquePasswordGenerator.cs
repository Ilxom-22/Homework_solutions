namespace Password;

public class UniquePasswordGenerator : SecurePasswordGenerator
{
    private readonly HashSet<string> passwords = new();



    public UniquePasswordGenerator(bool letters, byte length, bool digits = false) : base(letters, length, digits)
    {
    }



    public string GenerateUniquePassword()
    {
        string raw = GenerateSecurePassword(false);
        var rd = new Random();


        string uniquePassword = Shuffle(raw, rd);
        return !passwords.Contains(uniquePassword) ? uniquePassword : GenerateUniquePassword();
    }
}