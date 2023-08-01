namespace SmartHome;

public class SmartHomeService
{
    public SmartHomeService(string deviceName, List<Temperature> temperature)
    {
        _temperatureList = temperature;
        DeviceName = deviceName;
    }


    private string _deviceName;
    public bool IsActivated { get; private set; }
    public string DeviceName 
    { 
        get => _deviceName;
        init => _deviceName = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Invalid device name") : value;
    }
    private readonly List<Temperature> _temperatureList = new();



    public bool Activate()
    {
        IsActivated = true;
        return true;
    }



    public void DisplayHomeTemperature()
    {
        if (!IsActivated)
        {
            Console.WriteLine("SmartHome is not Activated! Please Activate it first!");
            return;
        }

        foreach (var temperature in _temperatureList)
        {
            Console.WriteLine(temperature);
        }
    }
}