using AutoMapper;
using management_system.Entities.DataModels;
using management_system.Entities.Dtos;
using management_system.Services.Interface;
using management_system.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Services.Services
{
    public class BrandService : GenericServices<BrandDto, Brand>, IBrandService
    {
        public BrandService(IBrandRepository brandRepository,
            IMapper mapper)
             : base(brandRepository, mapper)
        {

        }

        public async Task<object> getBrandList(SearchModel searchModel)
        {
            Expression<Func<Brand, object>> selectPredicate = x => new
            {
               id= x.BrandId,
               name=x.Name,
               shortname= x.ShortName
            };
            Expression<Func<Brand, dynamic>> orderbyPreadicate = x => x.BrandId;
            Expression<Func<Brand, bool>> whereConditionPredicate = x => x.IsDeleted == false;
            if (searchModel is not null)
            {
                if (searchModel.FilterField_1 != null && !String.IsNullOrWhiteSpace(searchModel.FilterField_1))
                {
                    whereConditionPredicate = whereConditionPredicate.Add(x => x.Name.ToLower().Contains(searchModel.FilterField_1.ToLower()));

                }
                if (searchModel.FilterField_2 != null && !String.IsNullOrWhiteSpace(searchModel.FilterField_2))
                {
                    whereConditionPredicate = whereConditionPredicate.Add(x => x.ShortName.ToLower().Contains(searchModel.FilterField_2.ToLower()));

                }
                if (searchModel.SortBy.ToLower() == "shortname")
                {
                    orderbyPreadicate = x => x.ShortName;
                }
                if (searchModel.SortBy.ToLower()== "name")
                {
                    orderbyPreadicate = x => x.Name;
                }
            }
            return await GetPaginatedListAsync(selectPredicate, whereConditionPredicate, orderbyPreadicate, searchModel.PageSize, searchModel.PageNo, searchModel.SortType);

        }
    }
}
