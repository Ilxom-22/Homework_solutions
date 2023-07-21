using System.Globalization;

namespace Events;

class Program
{
    static void Main(string[] args)
    {
        List<string> eventNames = new()
        {
            "TechConnect", "FutureTech Expo 2023", "DataCon", "CyberSecure Summit 2023", "CloudXchange"
        };

        List<DateTime> eventDates = new()
        {
            new(2023, 12, 10, 19, 20, 0),
            new (2023, 9, 12, 10, 30, 0),
            new(2024, 1, 15, 22, 0, 0),
            new(2023, 7, 30, 23, 40, 0),
            new(2024, 4, 29, 14, 0, 0)
        };

        SortEvents(eventNames, eventDates);

        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Console.WriteLine("EN");
        Print(eventNames, eventDates);
        Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
        Console.WriteLine("RU");
        Print(eventNames, eventDates);
        Thread.CurrentThread.CurrentCulture = new CultureInfo("uz");
        Console.WriteLine("UZ");
        Print(eventNames, eventDates);
    }

    private static void Print(List<string> eventNames, List<DateTime> eventDates)
    {
        for (var i = 0; i < eventNames.Count; i++)
            Console.WriteLine($"{eventNames[i]} - {eventDates[i]}");

        Console.WriteLine();
    }


    private static void SortEvents(List<string> eventNames, List<DateTime> eventDates)
    {
        for (var i = 0; i < eventDates.Count; i++)
            for (var j = i + 1; j < eventDates.Count; j++)
                if (eventDates[i] > eventDates[j])
                {
                    (eventDates[i], eventDates[j]) = (eventDates[j], eventDates[i]);
                    (eventNames[i], eventNames[j]) = (eventNames[j], eventNames[i]);
                }
    }
}
