using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public string Subject { get; set; } = default!;

    public EmailTemplate()
    {
        NotificationType = NotificationType.Email;
    }
}