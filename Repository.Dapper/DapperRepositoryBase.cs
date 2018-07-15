using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using System.Linq;
using Domain.Core;
using Domain.Core.IRespository;
using Repository.Dapper.Expressions;
using System.Data;

namespace Repository.Dapper
{
    public class DapperRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        protected IDapperUnitOfWork _unitOfWork;
        public DapperRepositoryBase(IDapperUnitOfWork unitOfWork)
        {
            //使用mysql
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            this._unitOfWork = unitOfWork;
        }

        #region Connection
        public virtual DbConnection Connection
        {
            get { return _unitOfWork.Connection; }
        }

        #endregion

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            var predicateGroup = predicate.ToPredicateGroup<TEntity, TPrimaryKey>();
            return Connection.Count<TEntity>(predicateGroup);
        }

        public override int Execute(string query, object parameters = null)
        {
            return Connection.Execute(query, parameters);
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            try
            {
                return Connection.Get<TEntity>(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var result = GetAll(predicate);
            return result.FirstOrDefault();
        }

        public override TEntity Get(TPrimaryKey id)
        {
            return Connection.Get<TEntity>(id);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return Connection.GetList<TEntity>();
        }

        public override IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var predicateGroup = predicate.ToPredicateGroup<TEntity, TPrimaryKey>();
            return Connection.GetList<TEntity>(predicateGroup);
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            var predicateGroup = predicate.ToPredicateGroup<TEntity, TPrimaryKey>();
            return Connection.GetPage<TEntity>(predicateGroup, null, pageNumber, itemsPerPage);
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            var predicateGroup = predicate.ToPredicateGroup<TEntity, TPrimaryKey>();
            return Connection.GetPage<TEntity>(predicateGroup, null, pageNumber, itemsPerPage);
        }


        public override TPrimaryKey InsertAndGetId(TEntity entity, IDbTransaction transaction = null)
        {
            TPrimaryKey id = Connection.Insert<TEntity>(entity, transaction as DbTransaction);
            return id;
        }

        public override IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            return Connection.Query<TEntity>(query, parameters);
        }

        public override TEntity Single(TPrimaryKey id)
        {
            return Connection.Get<TEntity>(id);
        }

        public override TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            var predicateGroup = predicate.ToPredicateGroup<TEntity, TPrimaryKey>();
            var result = Connection.GetList<TEntity>(predicateGroup);
            return result.FirstOrDefault();
        }

        public override void Insert(TEntity entity, IDbTransaction transaction = null)
        {
            Connection.Insert<TEntity>(entity, transaction as DbTransaction);
        }

        public override void Update(TEntity entity, IDbTransaction transaction = null)
        {
            Connection.Update<TEntity>(entity, transaction as DbTransaction);
        }

        public override void Delete(TEntity entity, IDbTransaction transaction = null)
        {
            Connection.Delete<TEntity>(entity, transaction as DbTransaction);
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null)
        {
            var result = GetAll(predicate);
            foreach (var p in result)
            {
                Connection.Delete<TEntity>(p, transaction as DbTransaction);
            }
        }
    }

    public class DapperRepositoryBase<TEntity> : DapperRepositoryBase<TEntity, int>, IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        public DapperRepositoryBase(IDapperUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
