using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper
{
    public interface IDapperBaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Single
        TEntity Single(TPrimaryKey id);

        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(TPrimaryKey id);
        #endregion

        #region Get
        TEntity Get(TPrimaryKey id);

        Task<TEntity> GetAsync(TPrimaryKey id);
        #endregion

        #region FirstOrDefault
        TEntity FirstOrDefault(TPrimaryKey id);

        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region GetAll
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);

        Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);

        IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);

        IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);
        #endregion

        #region Count
        int Count(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Query Sql
        IEnumerable<TEntity> Query(string query, object parameters = null);

        Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null);

        IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class;

        Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters = null) where TAny : class;
        #endregion

        #region Execute Sql
        int Execute(string query, object parameters = null);

        Task<int> ExecuteAsync(string query, object parameters = null);
        #endregion

        #region Insert
        void Insert(TEntity entity);

        TPrimaryKey InsertAndGetId(TEntity entity);

        Task InsertAsync(TEntity entity);

        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        #endregion

        #region Update
        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);
        #endregion

        #region Delete
        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
