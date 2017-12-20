using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WordRecoder.Domain;
using WordRecoder.Domain.IRepository;
using Dapper;

namespace WordRecoder.Infrastructure.Repository
{
    public class MigrationRepository : BaseRepository, IMigrationRepository
    {
        public MigrationRepository(IDbConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public void AddMigration(int version)
        {
            Connection.Execute(string.Format("insert into Migration (Version) values({0})", version));
        }

        public long GetMaxVersion()
        {
            try
            {
                return Connection.ExecuteScalar<long>("select Max(Version) from Migration");
            }
            catch (Exception)
            {
                return -1;
            }

        }
    }
}
