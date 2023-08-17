namespace Product.Models;

internal class ProductFilterModel
{
    public ProductFilterModel(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; set; }
    public string Type { get; set; }
}

