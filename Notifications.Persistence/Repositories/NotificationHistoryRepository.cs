using Notifications.Domain.Entities;
using Notifications.Persistence.DataContexts;
using Notifications.Persistence.Repositories.Interfaces;

namespace Notifications.Persistence.Repositories;

public class NotificationHistoryRepository : EntityRepositoryBase<NotificationHistory, NotificationsDbContext>, INotificationHistoryRepository
{
    public NotificationHistoryRepository(NotificationsDbContext notificationDbContext) : base(notificationDbContext)
    {
    }
}