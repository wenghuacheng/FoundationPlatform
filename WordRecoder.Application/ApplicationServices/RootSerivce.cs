using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.Dto;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Domain.Entities;
using WordRecoder.Domain.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace WordRecoder.Application.ApplicationServices
{
    public class RootSerivce : IRootSerivce
    {
        private IRootRepository mRootRepository;

        public RootSerivce(IRootRepository rootRepository)
        {
            this.mRootRepository = rootRepository;
        }


        public async Task AddOrUpdateRoot(RootDto rootDto)
        {
            if (rootDto.Id <= 0)
                mRootRepository.AddRoot(Mapper.Map<Root>(rootDto));
            else
                mRootRepository.UpdateRoot(Mapper.Map<Root>(rootDto));
        }

        public async Task<List<RootDto>> QueryRoot(RootDto searchModel)
        {
            List<RootDto> result = new List<RootDto>();
            List<Root> roots = mRootRepository.QueryRoot(searchModel.Id, searchModel.Name);
            result.AddRange(roots.Select(p => Mapper.Map<RootDto>(p)));

            return result;
        }

    }
}
