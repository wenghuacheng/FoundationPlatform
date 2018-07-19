using Domain.Core;
using Domain.Core.Entities;
using Domain.Core.IRespository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EFCore
{
    public class UnitOfWork<TDbContext> : IEFUnitOfWork<TDbContext>
        where TDbContext : DbContext
    {
        protected readonly TDbContext _context;

        public UnitOfWork(TDbContext context)
        {
            this._context = context;
        }

        public TDbContext DbContext => _context;


        public void SaveChange()
        {
            this._context.SaveChanges();
        }

        public void RegisterDelete(IEntity entity, IUnitOfWorkRepository repository)
        {

        }

        public void RegisterNew(IEntity entity, IUnitOfWorkRepository repository)
        {
        }

        public void RegisterUpdate(IEntity entity, IUnitOfWorkRepository repository)
        {
        }

        public IRepository<TEntity, TPrimaryKey> Repository<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
        {
            var repositoryType = typeof(EFCoreBaseRepository<TEntity, TPrimaryKey, TDbContext>);
            var repositoryInstance = Activator.CreateInstance(repositoryType, this) as IRepository<TEntity, TPrimaryKey>;
            return repositoryInstance;

        }
    }
}
