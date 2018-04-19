using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.Dto;
using WordRecoder.Domain.Entities;

namespace WordRecoder.Application.AutoMapperProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<RootDto, Root>();
            this.CreateMap<Root, RootDto>();
            this.CreateMap<WordDto, Word>();
        }
    }
}
