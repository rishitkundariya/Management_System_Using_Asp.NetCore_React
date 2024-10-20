﻿using management_system.Entities.DataModels;
using management_system.Entities.Dtos;
using management_system.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Services.Interface
{
    public interface IBrandService : IGenericServices<BrandDto,Brand>
    {
        Task<dynamic> getBrandList(SearchModel searchModel);
    }
}
