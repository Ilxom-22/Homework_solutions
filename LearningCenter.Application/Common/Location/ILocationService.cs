using LearningCenter.Domain.Entities.Common.Location;
using System.Linq.Expressions;

namespace LearningCenter.Application.Common.Location;

public interface ILocationService
{
    IQueryable<LocationEntity> Get(Expression<Func<LocationEntity, bool>>? predicate);

    ValueTask<LocationEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<LocationEntity> CreateAsync(LocationEntity location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationEntity> UpdateAsync(LocationEntity location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationEntity> DeleteAsync(LocationEntity location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationEntity> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}