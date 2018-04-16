using Domain.Core.IRepository;
using System.Data;

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
