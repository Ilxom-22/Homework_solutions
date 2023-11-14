using Notifications.Application.Common.Querying.Models;

namespace Notifications.Application.Common.Querying.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination pagination) => 
        source.Skip((pagination.PageToken - 1) * pagination.PageSize).Take(pagination.PageSize);

    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, FilterPagination pagination) =>
        source.Skip((pagination.PageToken - 1) * pagination.PageSize).Take(pagination.PageSize);
}