namespace Product.Models;

internal class Monitors : IProduct
{
    public Monitors(int id, string name, string description, double price, double displaySize, int refreshRate)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        DisplaySize = displaySize;
        RefreshRate = refreshRate;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOrdered { get; set; }
    public double Price { get; set; }

    public double DisplaySize { get; set; }
    public int RefreshRate { get; set; }

    public IProduct Copy()
    {
        return new Monitors(Id, Name, Description, Price, DisplaySize, RefreshRate);
    }
}
