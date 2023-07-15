namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to calculator app.");
            Console.WriteLine("Commands: \n" +
                              "c - continue\n" +
                              "e - exit");
            while (true)
            {
                
                double number1 = GetNumber();
                string operation = GetOperation();
                double number2 = GetNumber();

                Console.Write("Result: ");
                switch (operation)
                {
                    case "+":
                        Console.WriteLine(number1 + number2);
                        break;
                    case "-":
                        Console.WriteLine(number1 - number2);
                        break;
                    case "*":
                        Console.WriteLine(number1 * number2);
                        break;
                    case "/":
                        Console.WriteLine(number1 / number2);
                        break;
                }

                Console.Write("Input a command: ");
                bool exit = Console.ReadLine() == "e";

                if (exit)
                    return;
                
                Console.WriteLine();
            }
        }

        public static double GetNumber()
        {
            double number;
            bool ans;

            do
            {
                Console.Write("Input a number: ");
                ans = double.TryParse(Console.ReadLine(), out number);
            } while (!ans);
            
            return number;
        }

        public static string GetOperation()
        {
            string operation = string.Empty;
            bool isValidOperation;
            do
            {
                Console.Write("Input an operation: ");
                operation = Console.ReadLine();
                switch (operation)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        isValidOperation = true;
                        break;
                    default:
                        isValidOperation = false;
                        break;
                }
            } while (!isValidOperation);

            return operation;
        }

  
    }
}
