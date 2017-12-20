using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.IRepository;
using Dapper;
using WordRecoder.Domain;
using System.Data;

namespace WordRecoder.Infrastructure.Repository
{
    public class WordRootRepository : BaseRepository, IWordRootRepository
    {
        public WordRootRepository(IDbConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public void AddRelationRoot(int wordId, List<int> rootIds)
        {
            using (this.Connection)
            {
                if (Connection.State != ConnectionState.Open) Connection.Open();
                IDbTransaction transaction = this.Connection.BeginTransaction();
                rootIds.ForEach(p =>
                {
                    this.Connection.Execute("insert into wordrootrelation(WordId,RootId)Values(@WordId,@RootId)", new { WordId = wordId, RootId = p });
                });
                transaction.Commit();
            }
        }

        public void DeleteRelationRoot(int wordId)
        {
            this.Connection.Execute("delete from wordrootrelation where WordId=@WordId", new { WordId = wordId });
        }

        public void RemoveRelationRoot(int wordId, List<int> rootIds)
        {
            if (rootIds == null || rootIds.Count <= 0) return;

            using (this.Connection)
            {
                if (Connection.State != ConnectionState.Open) Connection.Open();
                IDbTransaction transaction = this.Connection.BeginTransaction();
                rootIds.ForEach(p =>
                {
                    this.Connection.Execute("delete from wordrootrelation where WordId=@WordId and RootId=@RootId", new { WordId = wordId, RootId = p });
                });
                transaction.Commit();
            }
        }

        public void UpdateRelationRoot(int wordId, List<Tuple<int, int>> rootIds)
        {
            using (this.Connection)
            {
                if (Connection.State != ConnectionState.Open) Connection.Open();
                IDbTransaction transaction = this.Connection.BeginTransaction();
                rootIds.ForEach(p =>
                {
                    this.Connection.Execute("update wordrootrelation set RootId=@NewRootId where WordId=@WordId and RootId=@RootId", new { WordId = wordId, RootId = p.Item1, NewRootId = p.Item2 });
                });
                transaction.Commit();
            }
        }
    }
}
