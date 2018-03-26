using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache : IDisposable
    {
        string Name { get; }

        TimeSpan DefaultSlidingExpireTime { get; set; }

        object Get(string key,Func<string, object> factory);

        object GetOrDefault(string key);

        void Set(string key, object value, TimeSpan? expireTime = null);

        void Clear();

        void Remove(string key);
    }
}
