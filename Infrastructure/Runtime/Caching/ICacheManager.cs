using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Runtime.Caching
{
    public interface ICacheManager
    {
        IReadOnlyList<ICache> GetAllCache();

        ICache GetCache(string name);
    }
}
