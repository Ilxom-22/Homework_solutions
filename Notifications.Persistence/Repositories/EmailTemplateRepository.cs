using Notifications.Domain.Entities;
using Notifications.Persistence.DataContexts;
using Notifications.Persistence.Repositories.Interfaces;

namespace Notifications.Persistence.Repositories;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationsDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationsDbContext notificationDbContext) : base(notificationDbContext)
    {
    }
}