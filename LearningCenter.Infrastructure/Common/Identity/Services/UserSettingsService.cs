using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Domain.Entities.Common.Identity;
using LearningCenter.Persistence.DataContexts;
using System.Linq.Expressions;

namespace LearningCenter.Infrastructure.Common.Identity.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly AppDbContext _appDbContext;

    public UserSettingsService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext; 
    }

    public IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>>? predicate)
        => predicate != null ? _appDbContext.UserSettings.Where(predicate) : _appDbContext.UserSettings;

    public async ValueTask<UserSettings?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _appDbContext.UserSettings.FindAsync(id);   

    public async ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.UserSettings.AddAsync(userSettings, cancellationToken);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return userSettings;
    }

    public async ValueTask<UserSettings> UpdateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUserSettings = await GetByIdAsync(userSettings.UserId, cancellationToken) ?? throw new ArgumentException("UserSettings not found.");

        foundUserSettings.IsDarkModeEnabled = userSettings.IsDarkModeEnabled;

        _appDbContext.UserSettings.Update(foundUserSettings);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return userSettings;
    }

    public async ValueTask<UserSettings> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundSettings = await GetByIdAsync(id, cancellationToken) ?? throw new ArgumentException("UserSettings not found");

        _appDbContext.UserSettings.Remove(foundSettings);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return foundSettings;
    }

    public async ValueTask<UserSettings> DeleteAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteByIdAsync(userSettings.UserId, saveChanges, cancellationToken);
}