namespace Weather;

public class Weather
{
    public DateTime Date { get; private set; }
    public string Forecast { get; set; }


    public Weather(DateTime date, string forecast)
    {
        if (date < DateTime.Today)
            throw new ArgumentException("Invalid Date for forecast!");

        Date = date;
        Forecast = forecast;
    }



    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Forecast}";
    }
}