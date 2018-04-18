using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Repository.Dapper
{
    public interface IDapperUnitOfWork<TEntity, TPrimaryKey> : IUnitOfWork<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        DbConnection Connection { get; set; }        
    }
}
