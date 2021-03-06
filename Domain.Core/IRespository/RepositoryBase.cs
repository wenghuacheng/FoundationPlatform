﻿using Domain.Core;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.IRespository
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, IUnitOfWorkRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public RepositoryBase()
        {
        }

        #region IMapperBaseRepository   
        #region Count     
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<int>(Count(predicate));
        }
        #endregion

        #region Delete

        public virtual Task DeleteAsync(TEntity entity, IDbTransaction transaction)
        {
            Delete(entity, transaction);
            return Task.FromResult(0);
        }

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction)
        {
            Delete(predicate, transaction);
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
        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity, IDbTransaction transaction)
        {
            return Task.FromResult<TPrimaryKey>(InsertAndGetId(entity, transaction));
        }

        public virtual Task InsertAsync(TEntity entity, IDbTransaction transaction)
        {
            Insert(entity, transaction);
            return Task.FromResult(0);
        }
        #endregion

        #region Query
        public virtual Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null)
        {
            return Task.FromResult<IEnumerable<TEntity>>(Query(query, parameters));
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
        public virtual Task UpdateAsync(TEntity entity, IDbTransaction transaction)
        {
            Update(entity, transaction);
            return Task.FromResult(0);
        }
        #endregion
        #endregion

        #region Abstract Method

        public abstract int Count(Expression<Func<TEntity, bool>> predicate);

        #region Delete
        public abstract void Delete(TEntity entity, IDbTransaction transaction);

        public abstract void Delete(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction);
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
        public abstract void Insert(TEntity entity, IDbTransaction transaction);

        public abstract TPrimaryKey InsertAndGetId(TEntity entity, IDbTransaction transaction);
        #endregion

        #region Query
        public abstract IEnumerable<TEntity> Query(string query, object parameters = null);
        #endregion

        #region Single
        public abstract TEntity Single(TPrimaryKey id);

        public abstract TEntity Single(Expression<Func<TEntity, bool>> predicate);
        #endregion

        public abstract void Update(TEntity entity, IDbTransaction transaction);

        #region IUnitOfWorkRepository
        public void PersistAdd(IEntity entity, IDbTransaction transaction)
        {
            this.Insert(entity as TEntity, transaction);
        }

        public void PersistRemove(IEntity entity, IDbTransaction transaction)
        {
            this.Delete(entity as TEntity, transaction);
        }

        public void PersistUpdate(IEntity entity, IDbTransaction transaction)
        {
            this.Update(entity as TEntity, transaction);
        }

        public void PersistAdd(TEntity entity, IDbTransaction transaction = null)
        {
            this.Insert(entity, transaction);
        }

        public void PersistRemove(TEntity entity, IDbTransaction transaction = null)
        {
            this.Delete(entity, transaction);
        }

        public void PersistUpdate(TEntity entity, IDbTransaction transaction = null)
        {
            this.Update(entity, transaction);
        }
        #endregion

        #endregion
    }
}
