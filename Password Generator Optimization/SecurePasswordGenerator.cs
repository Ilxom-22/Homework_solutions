namespace Password;

public class SecurePasswordGenerator : PasswordGenerator
{
    public SecurePasswordGenerator(bool letters, byte length, bool digits = false) : base(letters, length, digits)
    {
    }



    public string GenerateSecurePassword(bool symbols)
    {
        string raw = string.Empty;
        var rd = new Random();

        string numbers = "0123456789";
        string letters = "abcdefghijklmnopqrstuvwxyz";
        string characters = "!@#$%^&*()-_+=[]{}|\\:;\"'<>,.?/";


        while (raw.Length < _length)
        {
            if (_hasDigits)
                raw += numbers[rd.Next(numbers.Length)];
            if (_hasLetters)
                raw += letters[rd.Next(letters.Length)];
            if (symbols)
                raw += characters[rd.Next(characters.Length)];
        }
        return Shuffle(raw, rd);
    }
}