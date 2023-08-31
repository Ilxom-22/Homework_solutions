namespace Product_Task;

public class Product
{
    public Product(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public Product(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
    }

    private string? _name;
    private string? _description;

    public Guid Id { get; init; }
    public string? Name 
    {
        get => _name;
        private set => _name = !string.IsNullOrWhiteSpace(value) 
                                ? value 
                                : throw new ArgumentNullException(); 
    }
    public string? Description 
    { 
        get => _description;  
        private set => _description = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(); 
    }

    public override string ToString()
    {
        return $"{Name} - {Description}";
    }
}
