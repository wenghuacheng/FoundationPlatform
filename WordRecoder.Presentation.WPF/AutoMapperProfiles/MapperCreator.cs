using AutoMapper;
using System.Collections.Generic;
using WordRecoder.Presentation.WPF.AutoMapperProfiles;

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
