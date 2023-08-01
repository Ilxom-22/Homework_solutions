namespace SmartHome;

class Program
{
    static void Main(string[] args)
    {
        List<Temperature> temp = new List<Temperature>()
        {
            new (20, 22),
            new (20, 23),
            new (20, 21),
            new (20, 20),
            new (25, 21),
            new (25, 22),
            new (25, 23)
        };
        
        

        var smartHome = new SmartHomeService("Device", temp);
        smartHome.Activate();
        smartHome.DisplayHomeTemperature();
    }
}