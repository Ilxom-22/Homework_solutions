using FileBaseContext.Abstractions.Models.Entity;

namespace Empty_web_API_project.Models;

public class Order : IFileSetEntity<Guid>
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