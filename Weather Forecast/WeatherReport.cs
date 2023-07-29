namespace Weather;

public class WeatherReport
{
    protected readonly Dictionary<DateTime, Weather> _weatherForecast = new();



    public virtual void Add(Weather weather)
    {
        _weatherForecast[weather.Date] = weather;
    }



    public string Get(DateTime date)
    {
        var weather = Find(date);

        if (weather == null)
            return "Berilgan kunga ob-havo topilmadi, boshqa kunlar uchun qidiirb ko'ring";

        return weather.ToString();
    }



    private Weather? Find(DateTime date)
    {
        if (_weatherForecast.ContainsKey(date)) 
            return _weatherForecast[date];

        return null;
    }
}