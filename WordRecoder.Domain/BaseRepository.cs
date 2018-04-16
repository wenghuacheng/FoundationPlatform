using Domain.Core.IRepository;
using System.Data;

namespace WordRecoder.Domain
{
    public abstract class BaseRepository
    {
        public BaseRepository(IDbConnectionProvider connectionProvider)
        {
            Connection = connectionProvider.GetConnection();
        }

        private IDbConnection connection;
        protected IDbConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
    }
}
