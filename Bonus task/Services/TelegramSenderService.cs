using Bonus_task.Interfaces;

namespace Bonus_task.Services;

public class TelegramSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Sending telegram message to {userId} with content: {content}");

        return new ValueTask();
    }
}