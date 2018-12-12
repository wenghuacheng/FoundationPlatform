using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Repository.Dapper
{
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        IDbConnection Connection { get; }
    }
}
