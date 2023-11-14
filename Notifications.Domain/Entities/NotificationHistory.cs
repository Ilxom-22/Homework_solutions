using Notifications.Domain.Common.Entities;

namespace Notifications.Domain.Entities;

public class NotificationHistory : IEntity
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }
}