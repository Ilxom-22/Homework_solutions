using Notifications.Domain.Entities;
using Notifications.Persistence.DataContexts;
using Notifications.Persistence.Repositories.Interfaces;

namespace Notifications.Persistence.Repositories;

public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationsDbContext>, IEmailHistoryRepository
{
    public EmailHistoryRepository(NotificationsDbContext notificationDbContext) : base(notificationDbContext)
    {
    }
}