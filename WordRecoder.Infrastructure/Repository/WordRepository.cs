using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.Entities;
using WordRecoder.Domain.IRepository;
using Dapper;
using System.Data;
using WordRecoder.Domain;
using System.Linq;

namespace WordRecoder.Infrastructure.Repository
{
    public class WordRepository : BaseRepository, IWordRepository
    {
        public WordRepository(IDbConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public int AddWord(Word word)
        {
            var sql = "insert into word(Name,Mean,MnemonicWord,HelpMsg)Values(@Name,@Mean,@MnemonicWord,@HelpMsg);";
            sql += "SELECT last_insert_id();";
            return this.Connection.Query<int>(sql, word).FirstOrDefault();
        }
        
        public List<Word> QueryWord(int id, string name)
        {
            List<Word> result = new List<Word>();
            if (id <= 0 && string.IsNullOrWhiteSpace(name))
                return result;

            string sql = "select * from word where 1=1";
            if (id > 0) sql += string.Format(" and Id={0}", id);
            if (!string.IsNullOrWhiteSpace(name)) sql += string.Format(" and Name like '%{0}%'", name);

            return this.Connection.Query<Word>(sql).ToList();
        }

        public void UpdateWord(Word word)
        {
            this.Connection.Execute("update word  set Name=@Name,Mean=@Mean,MnemonicWord=@MnemonicWord,HelpMsg=@HelpMsg where Id=@Id", word);
        }
    }
}
