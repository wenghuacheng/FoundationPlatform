using Domain.Core;
using Domain.Core.IRespository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.EFCore
{
    public class EFCoreBaseRepository<TEntity, TPrimaryKey, TDbContext> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        protected IEFUnitOfWork<TDbContext> _unitOfWork;

        public EFCoreBaseRepository(IEFUnitOfWork<TDbContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region Properties
        public DbContext Context { get { return _unitOfWork.DbContext; } }

        public virtual DbSet<TEntity> Set => Context.Set<TEntity>();
        #endregion

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Count(predicate);
        }

        public override void Delete(TEntity entity, IDbTransaction transaction = null)
        {
            Set.Remove(entity);
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null)
        {
            var entities = GetAll(predicate);
            foreach (var entity in entities)
                Delete(entity, transaction);
        }

        public override int Execute(string query, object parameters = null)
        {
            return Context.Database.ExecuteSqlCommand(query, parameters);
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            return Set.FirstOrDefault(p => p.Id.Equals(id));
        }

        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        public override TEntity Get(TPrimaryKey id)
        {
            return Set.FirstOrDefault(p => p.Id.Equals(id));
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public override IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            return Set.Where(predicate).Skip(itemsPerPage * pageNumber).Take(pageNumber);
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            return Set.Where(predicate).Skip(itemsPerPage * pageNumber).Take(pageNumber);
        }

        public override void Insert(TEntity entity, IDbTransaction transaction = null)
        {
            Set.Add(entity);
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity, IDbTransaction transaction = null)
        {
            Set.Add(entity);
            return entity.Id;
        }

        public override IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            return Set.FromSql<TEntity>(query, new object[] { parameters });
        }


        public override TEntity Single(TPrimaryKey id)
        {
            return Set.FirstOrDefault(p => p.Id.Equals(id));
        }

        public override TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        public override void Update(TEntity entity, IDbTransaction transaction = null)
        {
            Set.Update(entity);
        }
    }

    public class EFCoreBaseRepository<TEntity, TDbContext> : EFCoreBaseRepository<TEntity, int, TDbContext>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : DbContext
    {
        public EFCoreBaseRepository(IEFUnitOfWork<TDbContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
