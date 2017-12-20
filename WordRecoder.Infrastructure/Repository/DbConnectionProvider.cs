using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WordRecoder.Domain.IRepository;

namespace WordRecoder.Infrastructure.Repository
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            return DbConnectionFactory.GetDatabaseMysqlConnection();
        }
    }
}
