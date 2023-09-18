public class WeatherReport
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public double TemperatureCelsius { get; set; }
    public double HumidityPercentage { get; set; }
    public double WindSpeedKmph { get; set; }
    public string WeatherDescription { get; set; }

    public override string ToString()
        => $@"ID: {Id}
Location: {Location}
Date: {Date}
Temperature Celsius: {TemperatureCelsius}
Humidity Percentage: {HumidityPercentage}
Wind Speed Kmph: {WindSpeedKmph}
Weather Description: {WeatherDescription}
";
}