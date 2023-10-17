using Bonus_task.Interfaces;

namespace Bonus_task.Services;

public class SmsSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Sending sms to {userId} with content: {content}");

        return new ValueTask();
    }
}