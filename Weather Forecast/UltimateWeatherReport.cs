namespace Weather;

public class UltimateWeatherReport : ValidatedWeatherReport
{
    public List<Weather> Get(DateTime startDate, int dayCount)
    {
        List<Weather> weatherList = new List<Weather>();
        if (!_weatherForecast.ContainsKey(startDate.AddDays(dayCount-1)))
            return weatherList;

        for (var i = 0; i < dayCount; i++)
        {
            weatherList.Add(_weatherForecast[startDate.AddDays(i)]);
        }

        return weatherList;
    }



    public List<Weather> Get(int dayCount)
    {
        return Get(DateTime.Today, dayCount);
    }
}