namespace Order_Task;

public class Order
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public Guid UserId { get; set; }

    public Order(int amount, Guid userId)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        UserId = userId;
    }
}