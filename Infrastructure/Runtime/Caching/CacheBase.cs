using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    /// <summary>
    /// 默认缓存实现类
    /// </summary>
    public abstract class CacheBase : ICache
    {
        private static object syncLock = new object();

        public CacheBase(string name)
        {
            this.Name = name;
            this.DefaultSlidingExpireTime = TimeSpan.FromHours(2);
        }

        public string Name { get; private set; }

        public TimeSpan DefaultSlidingExpireTime { get; set; }

        public abstract void Clear();

        public virtual void Dispose()
        {
        }

        public object Get(string key, Func<string, object> factory)
        {
            var item = GetOrDefault(key);
            if (item != null)
                return item;

            try
            {
                lock (syncLock)
                {
                    item = factory(key);
                    if (item != null)
                        Set(key, item, DefaultSlidingExpireTime);

                    return item;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public abstract object GetOrDefault(string key);

        public abstract void Remove(string key);

        public abstract void Set(string key, object value, TimeSpan? expireTime = null);
    }
}
