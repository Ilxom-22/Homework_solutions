namespace Shopping;

public class Product
{
    private Guid _id = Guid.NewGuid();
    public string name;


    public Product(string name)
    {
        this.name = name;
    }


    public override string ToString()
    {
        return name;
    }
}