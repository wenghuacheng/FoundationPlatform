using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.AutoMapperProfiles;
using WordRecoder.Application.Dto;
using WordRecoder.Domain.Entities;

namespace WordRecoder.Application
{
    public class MapperCreator
    {
        public static List<Profile> GetProfile()
        {
            return new List<Profile>()
            {
                new ServiceProfile()
            };
        }
    }
}
