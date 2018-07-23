using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Core
{
    /// <summary>
    /// 支持事务的操作的仓储
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        void PersistAdd(IEntity entity, IDbTransaction transaction = null);

        void PersistRemove(IEntity entity, IDbTransaction transaction = null);

        void PersistUpdate(IEntity entity, IDbTransaction transaction = null);
    }


    public interface IUnitOfWorkRepository<TEntity, TPrimaryKey> : IUnitOfWorkRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        void PersistAdd(TEntity entity, IDbTransaction transaction = null);

        void PersistRemove(TEntity entity, IDbTransaction transaction = null);

        void PersistUpdate(TEntity entity, IDbTransaction transaction = null);
    }
}
