using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    /// <summary>
    /// 强类型缓存包装类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class TypeCacheWapper<TKey, TValue> : ITypeCache<TKey, TValue>
    {
        public TypeCacheWapper(ICache cache)
        {
            this.InternalCache = cache;
        }

        public string Name
        {
            get { return InternalCache.Name; }
        }

        public TimeSpan DefaultSlidingExpireTime
        {
            get => InternalCache.DefaultSlidingExpireTime;
            set => InternalCache.DefaultSlidingExpireTime = value;
        }

        public ICache InternalCache { get; set; }

        public void Clear()
        {
            InternalCache.Clear();
        }

        public TValue Get(TKey key, Func<TKey, TValue> factory)
        {
            return (TValue)InternalCache.Get(key.ToString(), (k) => (object)factory(key));
        }

        public TValue GetOrDefault(TKey key)
        {
            return (TValue)InternalCache.GetOrDefault(key.ToString());
        }

        public void Remove(TKey key)
        {
            InternalCache.Remove(key.ToString());
        }

        public void Set(TKey key, TValue value, TimeSpan? expireTime = null)
        {
            InternalCache.Set(key.ToString(), value, expireTime);
        }
    }
}
