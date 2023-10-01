namespace Order_Task;

public class OrderProduct
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }

    public OrderProduct(Guid productId, Guid orderId)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        OrderId = orderId;
    }
}