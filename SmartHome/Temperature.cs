namespace SmartHome;

public class Temperature
{
    public Temperature(double expected, double current)
    {
        CurrentTemperature = current;
        ExpectedTemperature = expected;
    }

    public double CurrentTemperature { get; private set; }
    public double ExpectedTemperature { get; set; }


    public override string ToString()
    {
        return $"Expected - {ExpectedTemperature}, Current - {CurrentTemperature}";
    }
}