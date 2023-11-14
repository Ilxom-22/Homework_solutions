using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class EmailHistory : NotificationHistory
{
    public string Subject { get; set; } = default!;

    public EmailHistory()
    {
        NotificationType = NotificationType.Email;
    }
}