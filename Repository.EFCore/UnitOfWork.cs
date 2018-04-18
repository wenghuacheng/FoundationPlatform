using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EFCore
{
    public class UnitOfWork<TEntity, TPrimaryKey, TDbContext> : IEFUnitOfWork<TEntity, TPrimaryKey, TDbContext>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public UnitOfWork(TDbContext context)
        {
            this._context = context;
        }

        public TDbContext DbContext => _context;

        public void RegisterDelete(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository)
        {       
        }

        public void RegisterNew(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository)
        {            
        }

        public void RegisterUpdate(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository)
        {
        }

        public void SaveChange()
        {
            this._context.SaveChanges();
        }
    }
}
