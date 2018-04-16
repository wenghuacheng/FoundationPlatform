using DapperExtensions;
using Domain.Core;
using System;
using System.Linq.Expressions;

namespace Repository.Dapper.Expressions
{
    internal static class DapperExpressionExtensions
    {
        public static IPredicate ToPredicateGroup<TEntity, TPrimaryKey>(this Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity<TPrimaryKey>
        {
            var dev = new DapperExpressionVisitor<TEntity, TPrimaryKey>();
            IPredicate pg = dev.Process(expression);

            return pg;
        }
    }
}
