namespace LearningCenter.Domain.Entities.Common.Identity;

public class UserRole
{
    public Guid Id { get; set; }

    public string Role { get; set; } = default!;

    public Guid UserId { get; set; }
}