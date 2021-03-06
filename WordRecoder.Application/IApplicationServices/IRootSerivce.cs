﻿using Application.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Application.Dto;

namespace WordRecoder.Application.IApplicationServices
{
    public interface IRootSerivce : IApplicationService
    {
        Task AddOrUpdateRoot(RootDto rootDto);

        Task<List<RootDto>> QueryRoot(RootDto searchModel);
    }
}
