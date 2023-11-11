using BlogSite.Domain.Entities;
using System.Linq.Expressions;

namespace BlogSite.Application.Common.Foundations;

public interface IBlogService
{
    IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<Blog>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Blog> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}