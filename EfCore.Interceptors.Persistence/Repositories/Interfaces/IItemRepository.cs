using EfCore.Interceptors.Domain.Entities;
using System.Linq.Expressions;

namespace EfCore.Interceptors.Persistence.Repositories.Interfaces;

public interface IItemRepository
{
    IQueryable<Item> Get(Expression<Func<Item, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Item?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Item> CreateAsync(Item user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Item> UpdateAsync(Item user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Item?> DeleteByIdAsync(Guid itemId, bool saveChanges = true, CancellationToken cancellationToken = default);
}