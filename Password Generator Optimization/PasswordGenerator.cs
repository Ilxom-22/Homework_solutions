namespace Password;

public class PasswordGenerator
{
    protected bool _hasDigits;
    protected bool _hasLetters;
    protected byte _length;



    public PasswordGenerator(bool letters, byte length, bool digits = false)
    {
        _hasDigits = digits;
        _hasLetters = letters;
        _length = length;

        if (!digits && !letters)
            _hasLetters = true;
    }



    public string GeneratePassword()
    {
        string raw = string.Empty;
        var rd = new Random();

        string numbers = "0123456789";
        string letters = "abcdefghijklmnopqrstuvwxyz";
        

        while (raw.Length < _length)
        {
            if (_hasDigits)
                raw += numbers[rd.Next(numbers.Length)];
            if (_hasLetters)
                raw += letters[rd.Next(letters.Length)];
        }
        return Shuffle(raw, rd);
    }



    protected string Shuffle(string raw, Random rd)
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