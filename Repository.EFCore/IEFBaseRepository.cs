using Domain.Core;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EFCore
{
    public interface IEFBaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
    }
}
