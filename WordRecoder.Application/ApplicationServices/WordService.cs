using AutoMapper;
using System.Collections.Generic;
using WordRecoder.Application.Dto;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Domain.Entities;
using WordRecoder.Domain.IRepositories;

namespace WordRecoder.Application.ApplicationServices
{
    public class WordService : IWordService
    {
        private IWordRepository mWordRepository;
        private IWordRootRepository mWordRootRepository;

        public WordService(IWordRepository wordRepository, IWordRootRepository wordRootRepository)
        {
            this.mWordRepository = wordRepository;
            this.mWordRootRepository = wordRootRepository;
        }

        public void AddOrUpdateWord(WordDto word)
        {
            if (word.Id > 0)
            {
                //update
                mWordRepository.Update(Mapper.Map<Word>(word));
                HandleWordRootRelation(word.Id, word.RootRelations);
            }
            else
            {
                //add
                int id = mWordRepository.InsertAndGetId(Mapper.Map<Word>(word));
                HandleWordRootRelation(id, word.RootRelations);
            }
        }

        private void HandleWordRootRelation(int wordId, List<int> relations)
        {
            mWordRootRepository.DeleteRelationRoot(wordId);
            mWordRootRepository.AddRelationRoot(wordId, relations);
        }
    }
}
