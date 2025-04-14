using Udemy.Core.Entities;
using Udemy.Infrastructure.Extensions.Utils;
using System.Linq.Dynamic.Core;

namespace Udemy.Infrastructure.Extensions;
public static class RepositoryCourseExtensions
{
    public static IQueryable<Course> Sort(this IQueryable<Course> courses , string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return courses.OrderBy(e => e.Title);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Course>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return courses.OrderBy(e => e.Title);

        return courses.OrderBy(orderQuery);
    }
}
