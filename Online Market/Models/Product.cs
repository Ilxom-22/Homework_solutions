public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }



    public Product(string name, decimal price)
    {
        if (!ProductValidator.ValidName(name))
            throw new ArgumentException("Invalid product name!");

        if (!ProductValidator.ValidPrice(price))
            throw new ArgumentException("Invalid price!");

        Name = name;
        Price = price;
    }


    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }


    public override bool Equals(object? obj)
    {
        if (obj != null &&  obj is Product)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}