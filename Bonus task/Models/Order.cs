using FileBaseContext.Abstractions.Models.Entity;

namespace Bonus_task.Models;

public class Order : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public Guid UserId { get; set; }

    public Order(double amount, Guid userId)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        UserId = userId;
    }
}