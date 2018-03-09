using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IDapperBaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region IMapperBaseRepository   
        #region Count     
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<int>(Count(predicate));
        }
        #endregion

        #region Delete

        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }
        #endregion

        #region Execute Sql

        public virtual Task<int> ExecuteAsync(string query, object parameters = null)
        {
            return Task.FromResult<int>(Execute(query, parameters));
        }
        #endregion

        #region FirstOrDefault

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return Task.FromResult<TEntity>(FirstOrDefault(id));
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<TEntity>(FirstOrDefault(predicate));
        }
        #endregion

        #region Get

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<TEntity>>(GetAll());
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<IEnumerable<TEntity>>(GetAll(predicate));
        }

        public virtual Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            return Task.FromResult<IEnumerable<TEntity>>(GetAllPaged(predicate, pageNumber, itemsPerPage, sortingProperty, ascending));
        }

        public virtual Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            return Task.FromResult<IEnumerable<TEntity>>(GetAllPaged(predicate, pageNumber, itemsPerPage, ascending, sortingExpression));
        }

        public virtual Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return Task.FromResult<TEntity>(Get(id));
        }
        #endregion

        #region Insert
        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult<TPrimaryKey>(InsertAndGetId(entity));
        }

        public virtual Task InsertAsync(TEntity entity)
        {
            Insert(entity);
            return Task.FromResult(0);
        }
        #endregion

        #region Query
        public virtual Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null)
        {
            return Task.FromResult<IEnumerable<TEntity>>(Query(query, parameters));
        }

        public virtual Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters = null) where TAny : class
        {
            return Task.FromResult<IEnumerable<TAny>>(Query<TAny>(query, parameters));
        }
        #endregion

        #region Single   
        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<TEntity>(Single(predicate));
        }

        public virtual Task<TEntity> SingleAsync(TPrimaryKey id)
        {
            return Task.FromResult<TEntity>(Single(id));
        }
        #endregion

        #region Update
        public virtual Task UpdateAsync(TEntity entity)
        {
            Update(entity);
            return Task.FromResult(0);
        }
        #endregion
        #endregion

        #region Abstract Method

        public abstract int Count(Expression<Func<TEntity, bool>> predicate);

        #region Delete
        public abstract void Delete(TEntity entity);

        public abstract void Delete(Expression<Func<TEntity, bool>> predicate);
        #endregion

        public abstract int Execute(string query, object parameters = null);

        #region FirstOrDefault
        public abstract TEntity FirstOrDefault(TPrimaryKey id);

        public abstract TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Get&GetAll
        public abstract TEntity Get(TPrimaryKey id);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        public abstract IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);

        public abstract IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);
        #endregion

        #region Insert
        public abstract void Insert(TEntity entity);

        public abstract TPrimaryKey InsertAndGetId(TEntity entity);
        #endregion

        #region Query
        public abstract IEnumerable<TEntity> Query(string query, object parameters = null);

        public abstract IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class;
        #endregion

        #region Single
        public abstract TEntity Single(TPrimaryKey id);

        public abstract TEntity Single(Expression<Func<TEntity, bool>> predicate);
        #endregion

        public abstract void Update(TEntity entity);
        #endregion
    }
}
