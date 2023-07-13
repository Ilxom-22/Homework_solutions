namespace HT2
{
    class Program
    {
        static void Main(string[] args)
        {
            string email;
            int index = default;
            bool containsCapitalLetter = default;

            do
            {
                Console.Write("Input your email please: ");
                email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(email));


            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] != '.' && email[i] < 48)
                {
                    index = i;
                    break;
                }
                if (email[i] > '9' && email[i] < '@')
                {
                    index = i;
                    break;
                }
                if (email[i] > 'Z' && email[i] < 'a')
                {
                    index = i;
                    break;
                }
                if (email[i] > 'z')
                {
                    index = i;
                    break;
                }
                if (email[i] >= 'A' && email[i] <= 'Z')
                {
                    containsCapitalLetter = true;
                }
            }

            if (index == default)
            {
                if (containsCapitalLetter)
                    Console.WriteLine("Recommended version of the email: " + email.ToLower());
                else
                    Console.WriteLine("Everything is alright.");
            }
            else
                Console.WriteLine("There is an error in your email: " + email.Substring(index, 1));
        }
    }
}