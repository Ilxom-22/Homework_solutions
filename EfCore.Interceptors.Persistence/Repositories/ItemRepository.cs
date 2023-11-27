using EfCore.Interceptors.Domain.Entities;
using EfCore.Interceptors.Persistence.DataContexts;
using EfCore.Interceptors.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace EfCore.Interceptors.Persistence.Repositories;

public class ItemRepository(IdentityDbContext dbContext) : EntityRepositoryBase<Item, IdentityDbContext>(dbContext), IItemRepository
{
    ValueTask<Item> IItemRepository.CreateAsync(Item user, bool saveChanges, CancellationToken cancellationToken)
        => CreateAsync(user, saveChanges, cancellationToken);

    ValueTask<Item?> IItemRepository.DeleteByIdAsync(Guid itemId, bool saveChanges, CancellationToken cancellationToken)
        => DeleteByIdAsync(itemId, saveChanges, cancellationToken);

    IQueryable<Item> IItemRepository.Get(Expression<Func<Item, bool>>? predicate, bool asNoTracking)
        => Get(predicate, asNoTracking);

    ValueTask<Item?> IItemRepository.GetByIdAsync(Guid userId, bool asNoTracking, CancellationToken cancellationToken)
        => GetByIdAsync(userId, asNoTracking, cancellationToken);

    ValueTask<Item> IItemRepository.UpdateAsync(Item user, bool saveChanges, CancellationToken cancellationToken)
        => UpdateAsync(user, saveChanges, cancellationToken);
}