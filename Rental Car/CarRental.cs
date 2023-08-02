namespace Rental;

public abstract class CarRental
{
    public CarRental(string brandName)
    {
        if (string.IsNullOrWhiteSpace(brandName) || brandName.Length < 3)
            throw new ArgumentException("Invalid Brand Name!");

        BrandName = brandName;
        Id = Guid.NewGuid();
    }

    public bool IsRented { get; set; }
    public DateTime RentStartTime { get; set; }
    public double Balance { get; set; } = 0;
    public string BrandName { get; init; }
    public Guid Id { get; }
}