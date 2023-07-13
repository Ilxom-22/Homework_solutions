namespace HT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password;
            bool numbersIncluded = Include("Include numbers");
            bool lettersIncluded = Include("Include letters");
            bool charactersIncluded = Include("Include characters");
            byte passwordLength;
            bool converted;

            do
            {
                Console.Write("Input the password length: ");
                converted = byte.TryParse(Console.ReadLine(), out passwordLength);
            } while (!converted || passwordLength < 4 || passwordLength > 16);

            if (!numbersIncluded && !lettersIncluded && !charactersIncluded)
                lettersIncluded = true;

            password = GeneratePassword(numbersIncluded, lettersIncluded, charactersIncluded, passwordLength);
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

        private static string GeneratePassword(bool number, bool letter, bool character, byte length)
        {
            string raw = string.Empty;
            var rd = new Random();

            string numbers = "0123456789";
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string characters = "!@#$%^&*()-_+=[]{}|\\:;\"'<>,.?/";

            while (raw.Length < length)
            {
                if (number)
                    raw += numbers[rd.Next(numbers.Length)];
                if (letter)
                    raw += letters[rd.Next(letters.Length)];
                if (character)
                    raw += characters[rd.Next(characters.Length)];
            }

            raw = raw.Substring(0, length);
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
}