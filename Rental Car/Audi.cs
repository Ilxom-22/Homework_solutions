namespace Rental;

public sealed class Audi : CarRental
{
    public Audi(string modelName) : base("Audi")
    {
        if (string.IsNullOrWhiteSpace(modelName))
            throw new ArgumentException("Invalid Model Name");

        ModelName = modelName;
    }


    public string ModelName { get; init; }
    public const int RentPricePerHour = 20;
}