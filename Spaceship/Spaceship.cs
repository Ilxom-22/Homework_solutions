namespace Space;

public class Spaceship
{
    private string _trajectory;
    public string Name { get; init; }
    public int Fuel { get; } = 40;
    public int Speed { get; set; }
    public string Trajectory
    {
        set => _trajectory = value;
    }


    public override string ToString()
    {
        return $@"Name: {Name}
Fuel: {Fuel}
Speed: {Speed}";
    }
}