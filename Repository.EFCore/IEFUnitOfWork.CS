using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EFCore
{
    public interface IEFUnitOfWork<TEntity, TPrimaryKey, TDbContext> : IUnitOfWork<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        TDbContext DbContext { get; }
    }
}
