public class Order
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public Guid UserId { get; set; }

    public override string ToString()
        => @$"ID: {Id} 
Product name: {ProductName} 
User ID: {UserId}
";
}
