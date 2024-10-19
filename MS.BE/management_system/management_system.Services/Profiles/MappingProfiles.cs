using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using management_system.Entities.Dtos;
using management_system.Entities.DataModels;

namespace management_system.Services.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() { 
            CreateMap<BrandDto,Brand>().ReverseMap();

        }
    }
}
