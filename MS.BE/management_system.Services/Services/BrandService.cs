using AutoMapper;
using management_system.Entities.DataModels;
using management_system.Entities.Dtos;
using management_system.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Services.Services
{
    public class BrandService : GenericServices<BrandDto,Brand>, IBrandService
    {
        public BrandService(IBrandRepository brandRepository,
            IMapper mapper)
             : base(brandRepository, mapper)
        {

        }
    }
}
