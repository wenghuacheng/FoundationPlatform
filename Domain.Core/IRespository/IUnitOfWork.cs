using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Domain.Core
{
    public interface IUnitOfWork<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        void RegisterNew(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository);

        void RegisterDelete(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository);

        void RegisterUpdate(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository);

        void SaveChange();        
    }
}
