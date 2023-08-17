namespace Product.Models;

internal class Laptop : IProduct
{
    public Laptop(int id, string name, string description, double price, string cpuBrand, string cpuModel)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        CpuBrand = cpuBrand;
        CpuModel = cpuModel;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOrdered { get; set; }
    public double Price { get; set; }

    public string CpuBrand { get; set; }
    public string CpuModel { get; set; }

    public IProduct Copy()
    {
        return new Laptop(Id, Name, Description, Price, CpuBrand, CpuModel);
    }
}
