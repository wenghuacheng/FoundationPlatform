using Domain.Core;
using Domain.Core.Entities;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Domain.Core
{
    public interface IUnitOfWork
    {
        void RegisterNew(IEntity entity, IUnitOfWorkRepository repository);

        void RegisterDelete(IEntity entity, IUnitOfWorkRepository repository);

        void RegisterUpdate(IEntity entity, IUnitOfWorkRepository repository);

        IRepository<TEntity, TPrimaryKey> Repository<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;

        IUnitOfWorkRepository<TEntity, TPrimaryKey> UnitOfWorkRepository<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;


        void SaveChange();
    }
}
