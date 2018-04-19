using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.Dto;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using WordRecoder.Domain.IRepositories;
using Domain.Core.IRespository;

namespace WordRecoder.Application.ApplicationServices
{
    public class RootSerivce : IRootSerivce
    {
        private IRepository<Root> mRootRepository;

        public RootSerivce(IRepository<Root> rootRepository)
        {
            this.mRootRepository = rootRepository;
        }


        public async Task AddOrUpdateRoot(RootDto rootDto)
        {
            if (rootDto.Id <= 0)
                mRootRepository.Insert(Mapper.Map<Root>(rootDto));
            else
                mRootRepository.Update(Mapper.Map<Root>(rootDto));
        }

        public async Task<List<RootDto>> QueryRoot(RootDto searchModel)
        {
            List<RootDto> result = new List<RootDto>();
            List<Root> roots = mRootRepository.GetAll(p => p.Id == searchModel.Id && p.Name == searchModel.Name).ToList();
            result.AddRange(roots.Select(p => Mapper.Map<RootDto>(p)));

            return result;
        }

    }
}
