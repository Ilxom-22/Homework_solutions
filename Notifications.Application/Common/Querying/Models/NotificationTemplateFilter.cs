using Notifications.Domain.Enums;

namespace Notifications.Application.Common.Querying.Models;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}