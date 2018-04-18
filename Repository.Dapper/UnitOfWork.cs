using Domain.Core;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Repository.Dapper
{
    public class UnitOfWork<TEntity, TPrimaryKey> : IDapperUnitOfWork<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public UnitOfWork(DbConnection connection)
        {
            this.Connection = connection;
        }

        public DbConnection Connection { get; private set; }

        public readonly Dictionary<TEntity, IUnitOfWorkRepository<TEntity, TPrimaryKey>> addDict = new Dictionary<TEntity, IUnitOfWorkRepository<TEntity, TPrimaryKey>>();
        public readonly Dictionary<TEntity, IUnitOfWorkRepository<TEntity, TPrimaryKey>> deleteDict = new Dictionary<TEntity, IUnitOfWorkRepository<TEntity, TPrimaryKey>>();
        public readonly Dictionary<TEntity, IUnitOfWorkRepository<TEntity, TPrimaryKey>> updateDict = new Dictionary<TEntity, IUnitOfWorkRepository<TEntity, TPrimaryKey>>();


        public void SaveChange()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            var transaction = Connection.BeginTransaction();

            try
            {
                foreach (var p in addDict)
                {
                    p.Value.PersistAdd(p.Key);
                }

                foreach (var p in deleteDict)
                {
                    p.Value.PersistRemove(p.Key);
                }

                foreach (var p in updateDict)
                {
                    p.Value.PersistUpdate(p.Key);
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

        public void RegisterNew(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository)
        {
            addDict.Add(entity, repository);
        }

        public void RegisterDelete(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository)
        {
            deleteDict.Add(entity, repository);
        }

        public void RegisterUpdate(TEntity entity, IUnitOfWorkRepository<TEntity, TPrimaryKey> repository)
        {
            updateDict.Add(entity, repository);
        }

        private void Clear()
        {
            deleteDict.Clear();
            addDict.Clear();
            updateDict.Clear();
        }
    }
}
