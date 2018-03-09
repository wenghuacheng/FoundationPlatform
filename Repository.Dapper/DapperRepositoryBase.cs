using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using Dapper;

namespace Repository.Dapper
{
    public class DapperRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Connection
        public virtual DbConnection Connection
        {
            get { return null; }
        }
        #endregion

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override int Execute(string query, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override TEntity Get(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            throw new NotImplementedException();
        }

        public override void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TAny> Query<TAny>(string query, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public override TEntity Single(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public override TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
