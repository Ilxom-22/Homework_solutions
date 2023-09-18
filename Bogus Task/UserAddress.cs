public class UserAddress
{
    public long Id { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public long UserId { get; set; }

    public override string ToString()
        => @$"ID: {Id} 
Country: {Country} 
State: {State} 
Street: {Street} 
ZipCode: {ZipCode} 
User ID: {UserId}
";
}
