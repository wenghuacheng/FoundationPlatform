using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WordRecoder.Domain.IRepository;

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
