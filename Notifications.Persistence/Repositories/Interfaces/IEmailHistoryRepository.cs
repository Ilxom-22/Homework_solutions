using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface IEmailHistoryRepository
{
    IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = default,
        bool asNoTracking = false
    );

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}