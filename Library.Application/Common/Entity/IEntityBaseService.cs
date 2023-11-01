using System.Linq.Expressions;

namespace Library.Application.Common.Entity;

public interface IEntityBaseService<T> where T : class
{
    IQueryable<T> Get(Expression<Func<T, bool>>? predicate = null);

    ValueTask<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<ICollection<T>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

    ValueTask<T> CreateAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<T> UpdateAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<T> DeleteAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<T> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}