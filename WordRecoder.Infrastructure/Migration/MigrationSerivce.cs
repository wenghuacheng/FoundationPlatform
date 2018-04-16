using System;
using System.Collections.Generic;
using System.Linq;
using WordRecoder.Infrastructure.Repository;
using System.Data;
using Domain.Core.IRepository;

namespace WordRecoder.Infrastructure.Migration
{
    public class MigrationSerivce
    {
        private IMigrationRepository repository;

        public MigrationSerivce(IMigrationRepository repository)
        {
            this.repository = repository;
        }

        public void ExecuteMigration()
        {
            List<IMigration> migrations = new List<IMigration>();

            var types = this.GetType().Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IMigration)));
            types.ToList().ForEach(t =>
            {
                migrations.Add(System.Activator.CreateInstance(t) as IMigration);
            });

            IDbConnection conn = null;
            try
            {
                conn = DbConnectionFactory.GetDatabaseMysqlConnection();

                var currentVersion = repository.GetMaxVersion();
                if (currentVersion == -1)  //建库
                {
                    var createDbConnection = DbConnectionFactory.GetMysqlConnection();
                    try
                    {
                        var dbCreatorType = this.GetType().Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDbCreator)));
                        var dbCreator = System.Activator.CreateInstance(dbCreatorType.FirstOrDefault()) as IDbCreator;
                        dbCreator.Execute(createDbConnection);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        createDbConnection.Close();
                    }
                }

                migrations.Where(p => p.Version > currentVersion).OrderBy(p => p.Version).ToList().ForEach(migration =>
                  {
                      migration.Execute(conn);
                  });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

        }
    }
}
