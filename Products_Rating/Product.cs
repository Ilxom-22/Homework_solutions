namespace Products_Rating;

public class Product
{
    public Product(string name, byte stars, int inventory)
    {
        Name = name;
        Stars = stars;
        Inventory = inventory;
    }

    private string _name;
    private byte _stars;
    private int _inventory;

    public string Name { 
        get => _name; 
        set => _name = (!string.IsNullOrWhiteSpace(value)) 
            ? value 
            : throw new ArgumentNullException(nameof(Name), "Name can't be null!"); 
    }
    public byte Stars {
        get => _stars; 
        set => _stars = (value is > 0 and <= 5) 
            ? value 
            : throw new ArgumentOutOfRangeException(nameof(Stars), "Rating must be within 1 and 5 stars!"); 
    }
    public int Inventory { 
        get => _inventory; 
        set => _inventory = (value >= 0) 
            ? value 
            : throw new ArgumentOutOfRangeException(nameof(Inventory), "Inventory can't be negative number!"); 
    }
}

