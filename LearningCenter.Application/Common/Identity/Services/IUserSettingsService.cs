using LearningCenter.Domain.Entities.Common.Identity;
using System.Linq.Expressions;

namespace LearningCenter.Application.Common.Identity.Services;

public interface IUserSettingsService
{
    IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>>? predicate);

    ValueTask<UserSettings?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> UpdateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> DeleteAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}