using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using System.Linq;
using Domain.Core;

namespace Repository.Dapper
{
    public class DapperRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public DapperRepositoryBase()
        {
            //使用sql
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
        }

        #region Connection
        public virtual DbConnection Connection
        {
            get; set;
        }
        #endregion

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            //需要通过predicate转换为dapper的predicate(通过表达式树解析)
            var list = new List<IFieldPredicate>();
            list.Add(Predicates.Field<TEntity>(p => p.Id, Operator.Eq, 2));
            list.Add(Predicates.Field<TEntity>(p => p.Id, Operator.Eq, 1));          
            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, list.ToArray());
            return Connection.Count<TEntity>(predGroup);
        }

        public override void Delete(TEntity entity)
        {
            Connection.Delete<TEntity>(entity);
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var result = GetAll(predicate);
            foreach (var p in result)
                Delete(p);
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
            return Connection.GetList<TEntity>(predicate);
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            return Connection.GetPage<TEntity>(predicate, null, pageNumber, itemsPerPage);
        }

        public override IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            return Connection.GetPage<TEntity>(predicate, null, pageNumber, itemsPerPage);
        }

        public override void Insert(TEntity entity)
        {
            Connection.Insert<TEntity>(entity);
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity)
        {
            TPrimaryKey id = Connection.Insert<TEntity>(entity);
            return id;
        }

        public override IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            return Connection.Query<TEntity>(query, parameters);
        }

        public override IEnumerable<TAny> Query<TAny>(string query, object parameters = null)
        {
            return Connection.Query<TAny>(query, parameters);
        }

        public override TEntity Single(TPrimaryKey id)
        {
            return Connection.Get<TEntity>(id);
        }

        public override TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Connection.GetList<TEntity>(predicate);
            return result.FirstOrDefault();
        }

        public override void Update(TEntity entity)
        {
            Connection.Update<TEntity>(entity);
        }
    }
}
