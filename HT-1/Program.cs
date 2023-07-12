namespace HT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1:");
            FirstTask();
            Console.WriteLine("\nTask 2:");
            SecondTask();
            Console.WriteLine("\nTask 3:");
            ThirdTask();
        }



        public static void FirstTask()
        {
            string name;
            string lastName;
            byte age;
            bool success;

            // Name input.
            do
            {
                Console.Write("Input your name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            // Last Name input.
            do
            {
                Console.Write("Input your last name: ");
                lastName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(lastName));

            // Age input.
            do
            {
                Console.Write("Input your age: ");
                success = byte.TryParse(Console.ReadLine(), out age);
            } while (!success || age > 120 || age < 12);



            // Printing out the credentials.
            Console.WriteLine(@$"Name: {name}
Last Name: {lastName}
Age: {age}");
        }



        public static void SecondTask()
        {
            var today = DateTime.Today;
            Console.WriteLine(today.ToShortDateString());

            var date = DateTime.UnixEpoch;
            Console.WriteLine(date.ToString("yyyy dd MMMM"));

            byte age = 75;
            Console.WriteLine(age + " years");

            float price = 35.5f;
            Console.WriteLine(price.ToString("C"));

            string nickname = "Max Developer";
            Console.WriteLine(nickname);

        }


        public static void ThirdTask()
        {
            // Primitive Type.
            string today = "Wednesday";
            Console.WriteLine(today);

            // Complex Type.
            var worldDateTime = DateTime.UtcNow;
            Console.WriteLine(worldDateTime);

            // Value Type
            uint orderId = 22_325_853;
            Console.WriteLine("Order id: " + orderId);

            // Reference Type
            var customer = new Customer("James", "jamescarter@outlook.com", 1);
            Console.WriteLine();
            Console.WriteLine(customer.Introduce());
        }
    }
}

