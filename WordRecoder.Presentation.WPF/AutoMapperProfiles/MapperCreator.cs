using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Application.Dto;
using WordRecoder.Presentation.WPF.AutoMapperProfiles;
using static WordRecoder.Presentation.WPF.ViewModels.Word.RootEditorViewModel;

namespace WordRecoder.Presentation.WPF
{
    public class MapperCreator
    {
        public static List<Profile> GetProfile()
        {
            return new List<Profile>()
            {
                new RootProfile()
            };
        }
    }
}
