namespace Weather;

public class ValidatedWeatherReport : WeatherReport
{
    public override void Add(Weather weather)
    {
        if (_weatherForecast.ContainsKey(weather.Date))
            _weatherForecast[weather.Date] = weather;
        else
            _weatherForecast.Add(weather.Date, weather);
    }
}