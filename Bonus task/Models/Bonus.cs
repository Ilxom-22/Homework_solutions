using FileBaseContext.Abstractions.Models.Entity;

namespace Bonus_task.Models;

public class Bonus : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public Guid UserId { get; set; }

    public Bonus(double lastAmount, Guid userId)
    {
        Id = Guid.NewGuid();
        Amount = lastAmount;
        UserId = userId;
    }
}