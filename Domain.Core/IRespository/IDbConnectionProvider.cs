using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Core.IRepository
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
