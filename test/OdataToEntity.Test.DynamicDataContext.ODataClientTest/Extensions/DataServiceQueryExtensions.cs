using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.OData.Client;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Extensions
{
    public static class DataServiceQueryExtensions
    {
        //public static bool Any<TSource>(this IQueryable<TSource> source)
        //{
        //    if (source == null)
        //        throw new ArgumentNullException(nameof(source));

        //    return source.Provider.Execute<bool>((Expression)Expression.Call((Expression)null, CachedReflectionInfo.Count_TSource_1(typeof(TSource)), source.Expression));
        //}
        
        //public static bool Any<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        //{
        //    if (source == null)
        //        throw new ArgumentNullException(nameof(source));

        //    if (predicate == null)
        //        throw new ArgumentNullException(nameof(predicate));

        //    return source.Provider.Execute<bool>((Expression)Expression.Call((Expression)null, CachedReflectionInfo.Count_TSource_1(typeof(TSource)), source.Expression));
        //}
    }
}
