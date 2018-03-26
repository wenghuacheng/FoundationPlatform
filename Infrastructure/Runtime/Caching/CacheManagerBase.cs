using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    public abstract class CacheManagerBase : ICacheManager
    {
        protected readonly ConcurrentDictionary<string, ICache> Caches;

        public CacheManagerBase()
        {
            Caches = new ConcurrentDictionary<string, ICache>();
        }

        public IReadOnlyList<ICache> GetAllCache()
        {
            return Caches.Values.ToImmutableList();
        }

        public virtual ICache GetCache(string name)
        {
            return Caches.GetOrAdd(name, (key) =>
            {
                var cache = CreateCache(key);
                return cache;
            });
        }

        public abstract ICache CreateCache(string name);
    }
}
