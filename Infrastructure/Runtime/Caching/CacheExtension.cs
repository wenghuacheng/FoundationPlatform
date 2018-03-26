using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    public static class CacheExtension
    {
        public static ITypeCache<TKey, TValue> AsTyped<TKey, TValue>(this ICache cache)
        {
            return new TypeCacheWapper<TKey, TValue>(cache);
        }
    }
}
