using Caching.Domain.Common.Caching;
using Caching.Domain.Common.Comparers;
using Caching.Domain.Common.Entities;
using System.Linq.Expressions;

namespace Caching.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken) : CacheModel where TEntity : IEntity
{
    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = [];

    public List<(Expression<Func<TEntity, object>> KeySelector, bool IsAscending)> OrderingOptions { get; set; } = [];

    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(filter.ToString());

        foreach (var filter in OrderingOptions
            .Order(new OrderExpressionComparer<TEntity>()))
            hashCode.Add(filter.ToString());

        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is QuerySpecification<TEntity> querySpecification && querySpecification.GetHashCode() == GetHashCode(); 
}