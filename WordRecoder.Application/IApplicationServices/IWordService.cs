﻿using Application.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.Dto;

namespace WordRecoder.Application.IApplicationServices
{
    public interface IWordService : IApplicationService
    {
        void AddOrUpdateWord(WordDto word);
    }
}
