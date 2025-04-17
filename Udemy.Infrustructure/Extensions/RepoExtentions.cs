using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Infrastructure.Extensions.Utils;
using System.Linq.Dynamic.Core;

namespace Udemy.Infrastructure.Extensions
{
    public static class RepoExtention
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> values, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return values;

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<T>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return values;

            return values.OrderBy(orderQuery);
        }
    }
}
