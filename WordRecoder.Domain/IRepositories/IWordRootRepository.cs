using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Domain.IRepositories
{
    public interface IWordRootRepository : IRepository
    {
        /// <summary>
        /// 添加关联单词词根
        /// </summary>
        void AddRelationRoot(int wordId, List<int> rootIds);

        /// <summary>
        /// 删除关联单词词根
        /// </summary>
        /// <param name="wordId"></param>
        /// <param name="rootIds"></param>
        void RemoveRelationRoot(int wordId, List<int> rootIds);

        /// <summary>
        /// 更新关联单词词根
        /// </summary>
        /// <param name="wordId"></param>
        /// <param name="rootIds"></param>
        void UpdateRelationRoot(int wordId, List<Tuple<int, int>> rootId);

        /// <summary>
        /// 删除关联的词根
        /// </summary>
        /// <param name="wordId"></param>
        void DeleteRelationRoot(int wordId);
    }
}
