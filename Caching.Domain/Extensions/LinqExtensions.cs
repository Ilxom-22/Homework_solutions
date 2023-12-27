using Caching.Domain.Common.Entities;
using Caching.Domain.Common.Query;

namespace Caching.Domain.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplySpecification<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        source = source
            .ApplyPredicates(querySpecification)
                .ApplyOrdering(querySpecification)
                    .ApplyPagination(querySpecification);

        return source;
    }

    public static IEnumerable<TSource> ApplySpecification<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        source = source
            .ApplyPredicates(querySpecification)
                .ApplyOrdering(querySpecification)
                    .ApplyPagination(querySpecification);

        return source;
    }

    public static IQueryable<TSource> ApplyPredicates<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource: IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate));

        return source;
    }

    public static IEnumerable<TSource> ApplyPredicates<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        querySpecification.FilteringOptions.ForEach(predicate => source = source.Where(predicate.Compile()));

        return source;
    }

    public static IQueryable<TSource> ApplyOrdering<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        if (querySpecification.OrderingOptions.Count == 0)
            return source.OrderBy(entity => entity.Id);

        var initialOrdering = querySpecification.OrderingOptions[0];

        var initialQuery = initialOrdering.IsAscending ? source.OrderBy(initialOrdering.KeySelector) : source.OrderByDescending(initialOrdering.KeySelector);

        for (var i = 1; i < querySpecification.OrderingOptions.Count; ++i)
        {
            var ordering = querySpecification.OrderingOptions[i];
            initialQuery = ordering.IsAscending 
                ? initialQuery.ThenBy(ordering.KeySelector) 
                : initialQuery.ThenByDescending(ordering.KeySelector);
        }

        return initialQuery;
    }

    public static IEnumerable<TSource> ApplyOrdering<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        if (querySpecification.OrderingOptions.Count == 0)
            return source.OrderBy(entity => entity.Id);

        var initialOrdering = querySpecification.OrderingOptions[0];

        var initialQuery = initialOrdering.IsAscending ? source.OrderBy(initialOrdering.KeySelector.Compile()) : source.OrderByDescending(initialOrdering.KeySelector.Compile());

        for (var i = 1; i < querySpecification.OrderingOptions.Count; ++i)
        {
            var ordering = querySpecification.OrderingOptions[i];
            initialQuery = ordering.IsAscending
                ? initialQuery.ThenBy(ordering.KeySelector.Compile())
                : initialQuery.ThenByDescending(ordering.KeySelector.Compile());
        }

        return initialQuery;
    }

    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource: IEntity
    {
        return source
                .Skip((int)((querySpecification.PaginationOptions.PageToken - 1) * querySpecification.PaginationOptions.PageSize))
                    .Take((int)querySpecification.PaginationOptions.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, QuerySpecification<TSource> querySpecification) where TSource : IEntity
    {
        return source
                .Skip((int)((querySpecification.PaginationOptions.PageToken - 1) * querySpecification.PaginationOptions.PageSize))
                    .Take((int)querySpecification.PaginationOptions.PageSize);
    }
}