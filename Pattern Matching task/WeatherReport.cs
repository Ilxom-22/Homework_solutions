public class WeatherReport : IEntity
{
    public Guid Id { get; set; }
    public string State { get; set; }
    public double Degree { get; set; }

    public WeatherReport(string state, double degree)
    {
        Id = Guid.NewGuid();
        State = state;
        Degree = degree;
    }

    public override string ToString()
        => $"{State} {Degree}";
}