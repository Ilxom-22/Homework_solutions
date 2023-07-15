namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rd = new Random();

            string[] questions =
            {
                "Which of the following is not a primitive data type in C#",
                "Is it possible to declare a variable implicitly without initializing it",
                "In which example the float value is assigned to a variable named price correctly",
                "Which is the right syntax for declaring an array of type int with 3 elements",
                "If I want to access a not existing element of an array (example: array[-1]) is it going to throw an exception in " +
                "compile time or runtime"
            };

            string[] rightAnswers = { "string", "No", "float price = 53.34f;", "int[] array = new int[3];", "runtime"};
            string[] falseAnswers = { "double", "Yes", "float price = 53.12d;", "int array = new int(3);", "compile time"};
            int ball = default;
            List<int> invalidAnswers = new List<int>();



            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"{i}. {questions[i]}?");
                var options = rd.Next(2);
                bool answer;
                if (options == 1)
                {
                    Console.WriteLine($"A) {rightAnswers[i]}");
                    Console.WriteLine($"B) {falseAnswers[i]}");
                    Console.Write("Answer: ");
                    answer = Console.ReadLine().ToLower() == "a";
                }
                else
                {
                    Console.WriteLine($"A) {falseAnswers[i]}");
                    Console.WriteLine($"B) {rightAnswers[i]}");
                    Console.Write("Answer: ");
                    answer = Console.ReadLine().ToLower() == "b";
                }

                if (answer)
                    ball++;
                else
                    invalidAnswers.Add(i);
            }

            Console.WriteLine();
            Console.WriteLine($"Ball: {ball}");
            if (invalidAnswers.Count > 0)
                Console.WriteLine("Invalid Answers: ");

            for (int i = 0; i < invalidAnswers.Count; i++)
            {
                Console.WriteLine($"Question: {questions[invalidAnswers[i]]}?");
                Console.WriteLine($"Answer: {rightAnswers[invalidAnswers[i]]}");
                Console.WriteLine();
            }
        }
    }
}
