namespace EventScheduler
{
    class Prgram
    {
        static void Main(string[] args)
        {
            string[] events = {
                "Networking Mixer",
                "Charity Gala",
                "Community Block Party",
                "Art Exhibition Opening",
                "Fashion Show",
                "Movie Night Under the Stars",
                "Food Truck Festival",
                "Trivia Night",
                "Dance Party",
                "Comedy Show"
            };

            DateTime[] eventDates =
            {
                new (2023, 7, 22),
                new (2023, 11, 3),
                new (2023, 5, 14),
                new (2023, 9, 28),
                new (2023, 12, 9),
                new (2023, 8, 17),
                new (2023, 6, 5),
                new (2023, 10, 19),
                new (2023, 4, 30),
                new (2023, 8, 6)
            };

            int command;
            while (true)
            {
                command = GetOption();
                Console.WriteLine(command);

                if (command == 8)
                    break;

                Console.Clear();
                switch (command)
                {
                    case 1:
                        SortEvents(events, eventDates);
                        Console.Clear();
                        PrintEvents(events, eventDates);
                        break;
                    case 2:
                        FindEventByName(events, eventDates);
                        break;
                    case 3:
                        FindEventByDate(events, eventDates);
                        break;
                    case 4:
                        UpcomingEvents(events, eventDates, false);
                        break;
                    case 5:
                        PastEvents(events, eventDates, false);
                        break;
                    case 6:
                        UpcomingEvents(events, eventDates, true);
                        break;
                    case 7:
                        PastEvents(events, eventDates, true);
                        break;
                }

                Console.WriteLine("\nPress enter to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }



        private static int GetOption()
        {
            int option;
            bool isParsed;

            do
            {
                Console.Clear();
                Console.WriteLine(@"- Quyidaglardan bittasini tanlang
  eventlarni saralash - 1
  eventni nomi bo'yicha topish - 2
  eventni vaqti bo'yicha topish - 3
  kelayotgan eventlarni ko'rsatish - 4
  o'tib ketgan eventlarni ko'rsatish - 5
  kelayotgan eventlarni ko'rsatish ( yaqinligi bo'yicha ) - 6
  o'tib ketgan eventlarni ko'rsatish ( yaqinligi bo'yicha ) - 7
  dasturni yopish - 8");
                Console.WriteLine();
                isParsed = int.TryParse(Console.ReadLine(), out option);
            } while (!isParsed || option < 1 || option > 8);

            return option;
        }



        private static void SortEvents(string[] events, DateTime[] eventDates)
        {
            string mainQuestion = @"Choose the Sorting parameter
1. Sort by Name
2. Sort by Date";
            string secondQuestion = @"Choose the type of Sorting: 
1. Ascending
2. Descending";


            switch (GetInputValidated(mainQuestion))
            {
                case 1:

                    switch (GetInputValidated(secondQuestion))
                    {
                        case 1:
                            SortByNameAscending(events, eventDates);
                            break;
                        case 2:
                            SortByNameDescending(events, eventDates);
                            break;
                    }
                    break;
                case 2:

                    switch (GetInputValidated(secondQuestion))
                    {
                        case 1:
                            SortByDateAscending(events, eventDates);
                            break;
                        case 2:
                            SortByDateDescending(events, eventDates);
                            break;
                    }
                    break;
            }
        }



        private static void SortByNameAscending(string[] events, DateTime[] eventDates)
        {
            for (var i = 0; i < events.Length; i++)
                for (var j = i + 1; j < events.Length; j++)
                    if (events[i].CompareTo(events[j]) == 1)
                    {
                        (eventDates[i], eventDates[j]) = (eventDates[j], eventDates[i]);
                        (events[i], events[j]) = (events[j], events[i]);
                    }
        }



        private static void SortByNameDescending(string[] events, DateTime[] eventDates)
        {
            for (var i = 0; i < events.Length; i++)
                for (var j = i + 1; j < events.Length; j++)
                    if (events[i].CompareTo(events[j]) == -1)
                    {
                        (eventDates[i], eventDates[j]) = (eventDates[j], eventDates[i]);
                        (events[i], events[j]) = (events[j], events[i]);
                    }
        }



        private static void SortByDateAscending(string[] events, DateTime[] eventDates)
        {
            for (var i = 0; i < eventDates.Length; i++)
                for (var j = i + 1; j < eventDates.Length; j++)
                    if (eventDates[i] > eventDates[j])
                    {
                        (eventDates[i], eventDates[j]) = (eventDates[j], eventDates[i]);
                        (events[i], events[j]) = (events[j], events[i]);
                    }
        }



        private static void SortByDateDescending(string[] events, DateTime[] eventDates)
        {
            for (var i = 0; i < eventDates.Length; i++)
                for (var j = i + 1; j < eventDates.Length; j++)
                    if (eventDates[i] < eventDates[j])
                    {
                        (eventDates[i], eventDates[j]) = (eventDates[j], eventDates[i]);
                        (events[i], events[j]) = (events[j], events[i]);
                }
        }



        private static void PrintEvents(string[] events, DateTime[] eventDates)
        {
       
            for (var i = 0; i < events.Length; i++)
                Console.WriteLine($"{eventDates[i].ToShortDateString()} - {events[i]}");
        }



        private static int GetInputValidated(string question)
        {
            int input;
            bool isParsed;

            do
            {
                Console.Clear();
                Console.WriteLine($"{question}");
                isParsed = int.TryParse(Console.ReadLine(), out input);
            } while (!isParsed || input < 1 || input > 2);

            return input;
        }



        private static string GetInput(string question)
        {
            Console.Write($"{question}: ");
            return Console.ReadLine();
        }



        private static void FindEventByName(string[] events, DateTime[] eventDates)
        {
            string eventName = GetInput("Input the event name");
            bool isFound = false;

            for (var i  = 0; i < events.Length; i++)
                if (events[i].Contains(eventName, StringComparison.OrdinalIgnoreCase))
                {
                    isFound = true;
                    Console.WriteLine($"{eventDates[i].ToShortDateString()} - {events[i]}");
                }

            if (!isFound)
                Console.WriteLine("No events found!");
        }



        private static void FindEventByDate(string[] events, DateTime[] eventDates)
        {
            string eventDate = GetInput("Input the event date (month/date/year)");
            bool isFound = false;

            for (var i = 0; i < eventDates.Length; i++)
                if (eventDates[i].ToShortDateString().Contains(eventDate))
                {
                    isFound = true;
                    Console.WriteLine($"{eventDates[i].ToShortDateString()} - {events[i]}");
                }

            if (!isFound)
                Console.WriteLine("No events found!");
        }



        private static void UpcomingEvents(string[] events, DateTime[] eventDates, bool sorted)
        {
            var today = DateTime.Today;

            if (sorted)
                SortByDateAscending(events, eventDates);

            for (var i = 0; i < eventDates.Length; i++)
                if (eventDates[i] > today)
                    Console.WriteLine($"{eventDates[i].ToShortDateString()} - {events[i]}");
        }



        private static void PastEvents(string[] events, DateTime[] eventDates, bool sorted)
        {
            var today = DateTime.Today;

            if (sorted)
                SortByDateDescending(events, eventDates);

            for (var i = 0; i < eventDates.Length; i++)
                if (eventDates[i] < today)
                    Console.WriteLine($"{eventDates[i].ToShortDateString()} - {events[i]}");
        }
    }
}
