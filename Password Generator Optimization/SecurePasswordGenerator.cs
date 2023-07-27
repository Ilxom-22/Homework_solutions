namespace Password;

public class SecurePasswordGenerator : PasswordGenerator
{
    public SecurePasswordGenerator(bool letters, byte length, bool digits = false) : base(letters, length, digits)
    {
    }



    public string GenerateSecurePassword(bool symbols)
    {
        string raw = GeneratePassword();
        var rd = new Random();

        if (symbols)
        {
            string characters = "!@#$%^&*()-_+=[]{}|\\:;\"'<>,.?/";
            raw = raw.Substring(0, _length - (_length / 3));
            while (raw.Length < _length)
                raw += characters[rd.Next(characters.Length)];
        }


        return Shuffle(raw, rd);
    }
}