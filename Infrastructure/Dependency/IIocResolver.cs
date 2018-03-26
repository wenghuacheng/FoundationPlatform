using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dependency
{
    /// <summary>
    /// Ioc获取接口
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        T Resolve<T>();
    }
}
