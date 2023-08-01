namespace Space;

class Program
{
    static void Main(string[] args)
    {
        var spaceship = new Spaceship()
        {
            Name = "Stellar Voyager",
            Speed = 299,
            Trajectory = "Journey through the Asteroid Belt." +
                         "Navigating the treacherous asteroid belt between Mars and Jupiter, Starfire skillfully maneuvers through " +
                         "the clutter of rocky debris. The onboard AI system dynamically calculates the safest and fastest route, weaving " +
                         "the spaceship through the gaps between asteroids like a skilled pilot."
        };

        Console.WriteLine(spaceship);
        Console.WriteLine();

        spaceship.Speed = 425;
        spaceship.Trajectory = "Homecoming." +
                               "With its mission accomplished, Starfire enters Martian orbit once again. " +
                               "The spaceship's crew, excited to share their groundbreaking findings with the scientific community, " +
                               "prepares for a smooth docking procedure at the orbiting space station.";
        Console.WriteLine(spaceship);


    }
}