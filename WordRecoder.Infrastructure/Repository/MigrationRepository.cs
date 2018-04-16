using System;
using WordRecoder.Domain;
using Dapper;
using Domain.Core.IRepository;

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
