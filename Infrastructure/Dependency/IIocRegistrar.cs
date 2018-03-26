using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dependency
{
    /// <summary>
    /// Ioc注册接口
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <param name="dependencyLife"></param>
        void Register<TType, TImpl>(DependencyLifeStyle dependencyLife)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// 是否改类型以及被注册
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsRegistered(Type type);

        /// <summary>
        /// 是否该类型已经被注册
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        bool IsRegistered<TType>();
    }
}
