using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching.Memory
{
    /// <summary>
    /// 内存缓存管理类，用于管理创建缓存
    /// </summary>
    public class DefaultMemoryCacheManager : CacheManagerBase
    {
        public DefaultMemoryCacheManager() : base()
        {
        }

        public override ICache CreateCache(string name)
        {
            return new DefaultMemoryCache(name);
        }
    }
}
