using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface INotificationHistoryRepository
{
    IQueryable<NotificationHistory> Get(
        Expression<Func<NotificationHistory, bool>>? predicate = default,
        bool asNoTracking = false
    );

    ValueTask<NotificationHistory> CreateAsync(
        NotificationHistory notificationHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}