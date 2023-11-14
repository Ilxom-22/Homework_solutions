using Notifications.Domain.Entities;
using Notifications.Persistence.DataContexts;
using Notifications.Persistence.Repositories.Interfaces;

namespace Notifications.Persistence.Repositories;

public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationsDbContext>, ISmsHistoryRepository
{
    public SmsHistoryRepository(NotificationsDbContext notificationDbContext) : base(notificationDbContext)
    {
    }
}