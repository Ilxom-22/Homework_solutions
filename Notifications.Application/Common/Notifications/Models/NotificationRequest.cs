using Notifications.Domain.Enums;

namespace Notifications.Application.Common.Notifications.Models;

public class NotificationRequest
{
    public Guid ReceiverId { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public Dictionary<string, string> Variables { get; set; }

    public NotificationType? NotificationType { get; set; }

    public Guid? SenderId { get; set; }
}
