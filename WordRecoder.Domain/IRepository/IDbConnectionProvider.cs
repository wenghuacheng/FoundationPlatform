using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WordRecoder.Domain.IRepository
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
