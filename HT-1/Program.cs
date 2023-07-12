namespace HomeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
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
            string today = "Wednesday";
            var date = DateTime.UtcNow;
            Console.WriteLine(date);
        }
    }
}

