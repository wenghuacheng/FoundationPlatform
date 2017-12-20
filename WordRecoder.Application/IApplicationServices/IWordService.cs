using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.Dto;

namespace WordRecoder.Application.IApplicationServices
{
    public interface IWordService
    {
        void AddOrUpdateWord(WordDto word);
    }
}
