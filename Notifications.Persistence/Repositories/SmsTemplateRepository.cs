using Notifications.Domain.Entities;
using Notifications.Persistence.DataContexts;
using Notifications.Persistence.Repositories.Interfaces;

namespace Notifications.Persistence.Repositories;

public class SmsTemplateRepository : EntityRepositoryBase<SmsTemplate, NotificationsDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationsDbContext notificationsDbContext) : base(notificationsDbContext)
    {
    }
}