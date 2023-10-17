namespace Bonus_task.Interfaces;

public interface INotificationService
{
    ValueTask SendAsync(Guid userId, string content);
}