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
            this.CreateMap<RootDto, Root>()
                .ForMember(p => p.Derivative, (IMemberConfigurationExpression<RootDto, Root, object> opt) =>
            {
                opt.MapFrom<string>(src => string.Join(",", src.Derivative));
            });
            this.CreateMap<Root, RootDto>()
             .ForMember(p => p.Derivative, (IMemberConfigurationExpression<Root, RootDto, object> opt) =>
             {
                 opt.MapFrom<List<string>>(src => src.DerivativeList);
             });
            this.CreateMap<WordDto, Word>();
        }
    }
}
