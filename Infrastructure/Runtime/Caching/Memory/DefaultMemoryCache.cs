using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching.Memory
{
    /// <summary>
    /// 内存缓存类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DefaultMemoryCache : CacheBase
    {
        protected MemoryCache cache;

        public DefaultMemoryCache(string name)
            : base(name)
        {
            cache = new MemoryCache(new OptionsWrapper<MemoryCacheOptions>(new MemoryCacheOptions()));
        }

        public override void Clear()
        {
            cache.Dispose();
            cache = new MemoryCache(new OptionsWrapper<MemoryCacheOptions>(new MemoryCacheOptions()));
        }

        public override object GetOrDefault(string key)
        {
            return cache.Get(key);
        }

        public override void Remove(string key)
        {
            cache.Remove(key);
        }

        public override void Set(string key, object value, TimeSpan? expireTime = null)
        {
            if (expireTime.HasValue)
                cache.Set(key, value, expireTime.Value);
            else
                cache.Set(key, value);
        }

        public override void Dispose()
        {
            base.Dispose();
            cache.Dispose();
        }
    }
}
