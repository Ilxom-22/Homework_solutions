namespace VacationPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CompanyName = "The Travel Guru";
            const string NameToken = "{{Name}}";
            const string CompanyNameToken = "{{CompanyName}}";
            const string TicketDateToken = "{{TicketDate}}";


            Dictionary<string, string> messages = new()
            {
                { "Underage", "Uzr, hurmatli {{Name}} siz loyihadan foydalanish uchun kichkinasiz" },
                { "GoldenAge", "Uzr, hurmatli {{Name}} loyiha yoshlar uchun mo'ljallangan" }
            };


            LinkedList<string> emails = new();
            emails.AddFirst("Hello {{Name}}. Welcome to onboard. {{CompanyName}} Team.");
            emails.AddLast(
                "Your data is being processed and we will inform updates for you as soon as possible. {{CompanyName}} Team");
            emails.AddLast("Congratulations! Your flight ticket is booked for {{TicketDate}}. {{CompanyName}} Team.");


            Dictionary<DateTime, int> planes = new()
            {
                {new (2023, 08, 15, 10, 0, 0), 4},
                {new (2023, 09, 20, 12, 30, 0), 2},
                {new (2024, 02, 10, 15, 0, 0), 7}
            };


            Queue<string> passengers = new();
            passengers.Enqueue("Isabella");
            passengers.Enqueue("Ethan");
            passengers.Enqueue("Lucas");
            passengers.Enqueue("Liam");



            // Registration.
            Console.WriteLine("REGISTRATION: ");


            // Validating name.
            string name;
            do
            {
                Console.Write("Input your name: ");
                name = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(name) || !isAllLetter(name));


            // Validating age.
            byte age;
            do
            {
                Console.Write("Input your age: ");
            } while (!byte.TryParse(Console.ReadLine(), out age));


            // Checking the age.
            if (age < 18)
                Console.WriteLine(messages["Underage"].Replace(NameToken, name));
            else if (age >= 90)
                Console.WriteLine(messages["GoldenAge"].Replace(NameToken, name));
            else
                passengers.Enqueue(name);


            // Determining the flight date and time.
            DateTime flightDate = FindSuitableFlightTime(passengers.Count, planes);



            // Sending messages.
            while (passengers.Count > 0)
            {
                foreach (var message in emails)
                {
                    Console.WriteLine(message
                        .Replace(CompanyNameToken, CompanyName)
                        .Replace(NameToken, passengers.Peek())
                        .Replace(TicketDateToken, flightDate.ToString("g"))
                    );
                    Thread.Sleep(500);
                }
                    
                
                passengers.Dequeue();
                Console.WriteLine();
                Thread.Sleep(1000);
            }

        }


        private static bool isAllLetter(string name)
        {
            foreach (char letter in name)
            {
                if (!char.IsLetter(letter))
                    return false;
            }
            return true;
        }



        private static DateTime FindSuitableFlightTime(int passengerCount, Dictionary<DateTime, int> planes)
        {
            DateTime flightDate = new();
            foreach (var plane in planes)
            {
                if (plane.Value >= passengerCount)
                {
                    flightDate = plane.Key;
                    break;
                }
            }
            return flightDate;
        }
    }
}
