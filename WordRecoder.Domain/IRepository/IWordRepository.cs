using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.Entities;
using WordRecoder.Domain.ValueObjects;

namespace WordRecoder.Domain.IRepository
{
    public interface IWordRepository
    {
        int AddWord(Word word);

        void UpdateWord(Word word);

        List<Word> QueryWord(int id, string name);

        ///// <summary>
        ///// 添加关联的同义词
        ///// </summary>
        //void AddRelationSynonym(int wordId, List<int> syncWordIds);

        ///// <summary>
        ///// 添加关联单词的反义词
        ///// </summary>
        //void ModifyAntonym(int wordId, List<int> antonyWordIds);
    }
}
