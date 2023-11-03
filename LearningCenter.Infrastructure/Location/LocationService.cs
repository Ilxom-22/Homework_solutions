using LearningCenter.Application.Common.Location;
using LearningCenter.Domain.Entities.Common.Location;
using LearningCenter.Persistence.DataContexts;
using System.Linq.Expressions;

namespace LearningCenter.Infrastructure.Location;

public class LocationService : ILocationService
{
    private readonly AppDbContext _appDbContext;

    public LocationService(AppDbContext context)
    {
        _appDbContext = context;
    }

    public IQueryable<LocationEntity> Get(Expression<Func<LocationEntity, bool>>? predicate)
        => predicate != null ? _appDbContext.Locations.Where(predicate) : _appDbContext.Locations;

    public async ValueTask<LocationEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _appDbContext.Locations.FindAsync(id);

    public async ValueTask<LocationEntity> CreateAsync(LocationEntity location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Locations.AddAsync(location, cancellationToken);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return location;
    }

    public async ValueTask<LocationEntity> UpdateAsync(LocationEntity location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundLocation = await GetByIdAsync(location.Id, cancellationToken) ?? throw new ArgumentException("Location not found");

        foundLocation.Type = location.Type;
        foundLocation.ParentId = location.ParentId;
        foundLocation.Name = location.Name;

        _appDbContext.Locations.Update(foundLocation);

        if (saveChanges) await _appDbContext.SaveChangesAsync();

        return foundLocation;
    }

    public async ValueTask<LocationEntity> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundLocation = await GetByIdAsync(id, cancellationToken) ?? throw new ArgumentException("Location not found!");

        _appDbContext.Remove(foundLocation);

        if (saveChanges) await _appDbContext.SaveChangesAsync();

        return foundLocation;
    }

    public async ValueTask<LocationEntity> DeleteAsync(LocationEntity location, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteByIdAsync(location.Id, saveChanges, cancellationToken);
}