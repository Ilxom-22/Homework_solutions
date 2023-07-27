namespace AnimalHierarchy;

class Program
{
    static void Main(string[] args)
    {
        var shark = new GreatWhiteShark();
        var tiger = new Tiger();
        var sparrow = new Sparrow();

        shark.Swim();
        tiger.Run();
        sparrow.Fly();

    }
}