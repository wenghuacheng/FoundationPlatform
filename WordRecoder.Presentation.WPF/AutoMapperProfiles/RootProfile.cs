using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Application.Dto;
using WordRecoder.Presentation.WPF.CustomerControls.CustomerControls.MultiTextboxInput;
using WordRecoder.Presentation.WPF.Models.DisplayModels;
using static WordRecoder.Presentation.WPF.ViewModels.Word.RootEditorViewModel;
using static WordRecoder.Presentation.WPF.ViewModels.Word.WordEditorViewModel;

namespace WordRecoder.Presentation.WPF.AutoMapperProfiles
{
    public class RootProfile : Profile
    {
        public RootProfile()
        {
            this.CreateMap<RootDisplayModel, RootDto>()
             .ForMember(p => p.Derivative, (IMemberConfigurationExpression<RootDisplayModel, RootDto, object> opt) =>
             {
                 opt.MapFrom<List<string>>(src => src.Derivative.Select(t => t.Name).ToList());
             });
            this.CreateMap<RootDto, RootDisplayModel>()
                .ForMember(p => p.Derivative, opt =>
                {
                    opt.ResolveUsing<RootDtoToRootDisplayModelDerivativeValueResolver>();
                });

            this.CreateMap<WordDisplayModel, WordDto>()
            .ForMember(p => p.RootRelations, (IMemberConfigurationExpression<WordDisplayModel, WordDto, object> opt) =>
              {
                  opt.MapFrom<List<int>>(src => src.RootIds);
              });
        }
    }

    public class RootDtoToRootDisplayModelDerivativeValueResolver : IValueResolver<RootDto, RootDisplayModel, BindableCollection<InputModel>>
    {
        public BindableCollection<InputModel> Resolve(RootDto source, RootDisplayModel destination, BindableCollection<InputModel> destMember, ResolutionContext context)
        {
            BindableCollection<InputModel> result = new BindableCollection<InputModel>();
            result.AddRange(source.Derivative.Select(p => new InputModel() { Name = p }));
            return result;
        }
    }
}
