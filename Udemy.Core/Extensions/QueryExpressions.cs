using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Udemy.Core.Extensions;
public static class QueryExpressions
{
    /// <summary>
    /// Dynamically includes multi-level navigation properties in a query using lambda expressions.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The query to apply includes to.</param>
    /// <param name="includePaths">The lambda expressions representing the multi-level navigation properties.</param>
    /// <returns>The query with multi-level includes applied.</returns>
    public static IQueryable<T> IncludeRelated<T>(this IQueryable<T> query ,
        params Func<IQueryable<T> , IQueryable<T>>[] includes) where T : class
    {
        if (includes != null && includes.Any())
        {
            foreach (var include in includes)
            {
                query = include(query);
            }
        }
        return query;
    }
}
