namespace Product.Models;

internal class Chair : IProduct
{
    public Chair(int id, string name, string description, double price, int maxWeight, string material)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        MaxWeight = maxWeight;
        Material = material;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOrdered { get; set; }
    public double Price { get; set; }

    public int MaxWeight { get; set; }
    public string Material { get; set; }

    public IProduct Copy()
    {
        return new Chair(Id, Name, Description, Price, MaxWeight, Material);
    }
}
