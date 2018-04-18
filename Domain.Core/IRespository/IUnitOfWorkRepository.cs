using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    /// <summary>
    /// 支持事务的操作
    /// </summary>
    public interface IUnitOfWorkRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        void PersistAdd(TEntity entity);

        void PersistRemove(TEntity entity);

        void PersistUpdate(TEntity entity);
    }
}
