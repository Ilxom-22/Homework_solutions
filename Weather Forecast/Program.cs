namespace Weather;

class Program
{
    static void Main(string[] args)
    {
        // Weather Report.
        List<Weather> weatherList = new()
        {
            new(new DateTime(2023, 12, 12),
                "Mostly sunny skies with a high of 28°C. Light breeze from the northeast at 5 mph. Enjoy a pleasant day outdoors!"),
            new(new DateTime(2023, 12, 14),
                "Cloudy with occasional drizzles. Highs around 18°C. Grab your umbrella and a light jacket for a damp day."),
            new(new DateTime(2023, 7, 29),
                " Clear skies and warm temperatures. Expect a high of 26°C with a gentle sea breeze from the east at 10 mph. Perfect beach weather!"),
            new(new DateTime(2023, 9, 22),
                "Partly cloudy skies with a high of 32°C. Humidity levels are moderate, so stay hydrated and find shade when needed."),
            new(new DateTime(2023, 8, 2),
                "Scattered thunderstorms throughout the day. Highs near 26°C. Don't forget your rain gear and be cautious of localized flooding."),
            new(new DateTime(2023, 10, 1),
                "Sunny and warm with a high of 24°C. Light southeasterly winds at 8 mph. Ideal conditions for exploring the city and its beautiful landscapes.")
        };

        var report = new WeatherReport();

        foreach (var weather in weatherList)
            report.Add(weather);

        Console.WriteLine(report.Get(new DateTime(2023, 12, 12)));
        Console.WriteLine(report.Get(new DateTime(2023, 1, 1)));
        Console.WriteLine();



        // ValidatedWeatherReport.
        List<Weather> validatedWeather = new()
        {
            new (new DateTime(2023, 11, 5),
                "Foggy morning, clearing up later. Highs around 15°C. Drive carefully and keep your headlights on during low visibility."),
            new (new DateTime(2023, 9, 10),
                "Intermittent showers with a chance of thunderstorms. Highs near 20°C. Keep an umbrella handy and stay indoors during lightning."),
            new (new DateTime(2023, 8, 20),
                "Partly sunny with a high of 30°C. UV index is high, apply sunscreen and stay hydrated when outdoors."),
            new (new DateTime(2023, 10, 18),
                "Overcast skies with a chance of rain. Highs around 12°C. Dress warmly and bring an umbrella."),
            new(new DateTime(2023, 10, 1),
                "Sunny and warm with a high of 24°C. Light southeasterly winds at 8 mph. Ideal conditions for exploring the city and its beautiful landscapes."),
            new(new DateTime(2023, 10, 1),
                "Sunny and warm with a high of 24°C. Light southeasterly winds at 8 mph. Ideal conditions for exploring the city and its beautiful landscapes.")
        };

        var validatedReport = new ValidatedWeatherReport();
        foreach (var weather in validatedWeather)
            validatedReport.Add(weather);



        // UltimateWeatherReport
        List<Weather> ultimateWeather = new()
        {
            new(new DateTime(2023, 7, 29),
                "Expect a sunny day with clear skies and highs reaching 28°C. It will be a perfect day for outdoor activities, so make sure to stay hydrated and wear sunscreen."),
            new(new DateTime(2023, 7, 30),
                "Partly cloudy skies throughout the day with a chance of isolated showers in the afternoon. Temperatures will range from 22°C to 26°C, providing a pleasant day for most."),
            new(new DateTime(2023, 7, 31),
                "A mix of sun and clouds with a slight breeze. The temperature will hover around 24°C. Grab a light jacket if you're heading out in the evening."),
            new(new DateTime(2023, 8, 1),
                "Expect overcast skies with occasional drizzles. The temperature will stay mild, reaching 20°C. Don't forget to carry an umbrella to stay dry."),
            new(new DateTime(2023, 8, 2),
                "A sudden change in weather as thunderstorms are predicted throughout the day. Be cautious of heavy rainfall and possible lightning. Stay indoors if possible and keep yourself updated on weather alerts."),
            new(new DateTime(2023, 8, 3),
                "The storms will clear, giving way to a partly cloudy day. Temperatures will rise to 25°C, and there might be some puddles around, so watch your step."),
            new(new DateTime(2023, 8, 4),
                "Mostly sunny with a few scattered clouds. Warm temperatures at 27°C. A great day for outdoor enthusiasts."),
            new(new DateTime(2023, 8, 5),
                "Cold front moves in, dropping temperatures to 18°C. Bundle up for a brisk day."),
            new(new DateTime(2023, 8, 6),
                "Chilly and partly cloudy. Temperatures ranging from 16°C to 20°C. Bring an umbrella for a chance of drizzle."),
            new(new DateTime(2023, 8, 7),
                "Clear skies and abundant sunshine return. Pleasant day with temperatures around 23°C.")
        };

        var ultimateReport = new UltimateWeatherReport();

        foreach (var weather in ultimateWeather)
            ultimateReport.Add(weather);

        var dayReport = ultimateReport.Get(3);
        Display(dayReport);


        var specificReport = ultimateReport.Get(new DateTime(2023, 8, 2), 7);
        Display(specificReport);


    }

    private static void Display(List<Weather> dayReport)
    {
        if (dayReport.Count == 0)
            Console.WriteLine("Uzr, to'liq ma'lumot yo'q");
        else
            foreach (var day in dayReport)
                Console.WriteLine(day);

        Console.WriteLine();
    }
}