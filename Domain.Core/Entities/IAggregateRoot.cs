using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAggregateRoot<T> : IEntity<T>
    {
    }
}
