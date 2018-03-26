using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    public interface ITypeCache<TKey, TValue>
    {
        string Name { get; }

        TimeSpan DefaultSlidingExpireTime { get; set; }

        ICache InternalCache { get; set; }

        TValue Get(TKey key, Func<TKey, TValue> factory);

        TValue GetOrDefault(TKey key);

        void Set(TKey key, TValue value, TimeSpan? expireTime = null);

        void Clear();

        void Remove(TKey key);
    }
}
