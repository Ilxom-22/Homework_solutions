namespace Rental;

public sealed class BMW : CarRental
{
    public BMW(string modelName) : base("BMW")
    {
        if (string.IsNullOrWhiteSpace(modelName))
            throw new ArgumentException("Invalid Model Name");

        ModelName = modelName;
    }



    public string ModelName { get; init; }
    public const int RentPricePerHour = 30;
}