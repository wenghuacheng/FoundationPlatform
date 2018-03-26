using Infrastructure.Runtime.Caching;
using Infrastructure.Runtime.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Infrastructure.Runtime.Caching;

namespace Infrastructure.Test
{
    [TestClass]
    public class MemoryCacheTest
    {
        private readonly ICacheManager _cacheManager;
        private readonly ITypeCache<int, MyCacheItem> _cache;

        public MemoryCacheTest()
        {
            _cacheManager = new DefaultMemoryCacheManager();
            _cache = _cacheManager.GetCache("MyCacheItems").AsTyped<int,MyCacheItem>();
        }

        [TestMethod]
        public void Memory_Cache_Test()
        {
            var item = new MyCacheItem { Value = 42 };
            _cache.Set(item.Value, item, TimeSpan.FromSeconds(2));
            var value = _cache.GetOrDefault(item.Value);
            Assert.AreEqual(value, item);

            Thread.Sleep(5000);

            value = _cache.GetOrDefault(item.Value);
            Assert.AreEqual(value, null);
        }

        public class MyCacheItem
        {
            public int Value { get; set; }
        }
    }
}
