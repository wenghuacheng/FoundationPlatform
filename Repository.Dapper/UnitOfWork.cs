using Domain.Core;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Dapper;
using System.Transactions;

namespace Repository.Dapper
{
    public class UnitOfWork : IDapperUnitOfWork
    {
        public readonly Dictionary<IEntity, IUnitOfWorkRepository> addDict = new Dictionary<IEntity, IUnitOfWorkRepository>();
        public readonly Dictionary<IEntity, IUnitOfWorkRepository> deleteDict = new Dictionary<IEntity, IUnitOfWorkRepository>();
        public readonly Dictionary<IEntity, IUnitOfWorkRepository> updateDict = new Dictionary<IEntity, IUnitOfWorkRepository>();

        private readonly Dictionary<string, object> repositories = new Dictionary<string, object>();

        public UnitOfWork(DbConnection connection)
        {
            this.Connection = connection;
        }

        public DbConnection Connection { get; private set; }


        public void RegisterNew(IEntity entity, IUnitOfWorkRepository repository)
        {
            addDict.Add(entity, repository);
        }

        public void RegisterDelete(IEntity entity, IUnitOfWorkRepository repository)
        {
            deleteDict.Add(entity, repository);
        }

        public void RegisterUpdate(IEntity entity, IUnitOfWorkRepository repository)
        {
            updateDict.Add(entity, repository);
        }

        public void SaveChange()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            using (var transaction = Connection.BeginTransaction())
            {

                try
                {
                    foreach (var p in addDict)
                    {
                        p.Value.PersistAdd(p.Key, transaction);
                    }

                    foreach (var p in deleteDict)
                    {
                        p.Value.PersistRemove(p.Key, transaction);
                    }

                    foreach (var p in updateDict)
                    {
                        p.Value.PersistUpdate(p.Key, transaction);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    Clear();
                }
            }
        }

        private void Clear()
        {
            deleteDict.Clear();
            addDict.Clear();
            updateDict.Clear();
        }

        public IRepository<TEntity, TPrimaryKey> Repository<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
        {
            var repositoryType = typeof(DapperRepositoryBase<TEntity, TPrimaryKey>);
            var repositoryInstance = Activator.CreateInstance(repositoryType, this) as IRepository<TEntity, TPrimaryKey>;
            return repositoryInstance;

        }
    }
}
