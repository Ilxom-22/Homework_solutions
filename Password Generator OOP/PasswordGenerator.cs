namespace Password;

public class PasswordGenerator
{
    private bool _hasDigits;
    private bool _hasLetters;
    private bool _hasSymbols;
    private byte _length;



    public PasswordGenerator(bool digits, bool letters, bool symbols, byte length)
    {
        _hasDigits = digits;
        _hasLetters = letters;
        _hasSymbols = symbols;
        _length = length;

        if (!digits && !letters && !symbols)
            _hasLetters = true;
    }



    public string GeneratePassword()
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
            if (_hasSymbols)
                raw += characters[rd.Next(characters.Length)];
        }
        return Shuffle(raw, rd);
    }



    private string Shuffle(string raw, Random rd)
    {
        raw = raw.Substring(0, _length);
        char[] password = raw.ToCharArray();


        //Fisher-Yates Shuffle Algorithm.
        for (int i = password.Length - 1; i > 0; i--)
        {
            int j = rd.Next(i + 1);
            (password[i], password[j]) = (password[j], password[i]);
        }

        return new string(password);
    }
}