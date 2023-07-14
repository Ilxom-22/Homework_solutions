using Username_Generator;

namespace Username_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] predefinedAddings =
            {
                "ninja", "explorer", "unleashed", "extraordinaire", "dynamo", "innovator", 
                "scribe", "wizard", "enigma", "adventures", "journeyman", "phantom"
            };
            char[] predefinedSeperators = { '-', '_', '.' };
            var rd = new Random();
            string name = GetInput("Name");
            string lastName = GetInput("Last Name");


            Console.Write("Suggested username: ");
            if (isAvailable(rd))
                Console.WriteLine(name.ToLower());
            else
                Console.WriteLine(
                    $"{name}" +
                    $"{predefinedSeperators[rd.Next(predefinedSeperators.Length)]}" +
                    $"{predefinedAddings[rd.Next(predefinedAddings.Length)]}");
        }

        private static string GetInput(string question)
        {
            string input;
            do
            {
                Console.Write($"Input your {question}: ");
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(input) || !input.isAllLetter()); // isAllLetter is an extension method for string
                                                                               // which is defined in the isAllLetterString.cs.

            return input;
        }

        private static bool isAvailable(Random rd)
        {
            var availibility = rd.Next(3);

            return availibility == 1;
        }
    }
}
