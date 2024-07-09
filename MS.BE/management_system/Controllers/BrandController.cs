using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using management_system.Filters;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using management_system.Entities.Dtos;
using management_system.Services.Interface;
using management_system.Helpers;
using management_system.Shared.Constants;
using management_system.Shared.Utilities;

namespace management_system.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase 
    {
        private  IValidator<BrandDto> _validator;
        private  IBrandService _brandService;
        public BrandController(IValidator<BrandDto> validator, IBrandService brandService)
        {
            _validator = validator ?? throw new NullReferenceException();
            _brandService = brandService ?? throw new NullReferenceException();
        }

        [HttpPost]
        [TypeFilter(typeof(ModelValidatorFilter<BrandDto>))]
        public async Task<IActionResult> AddBrand(BrandDto dto)
        {
            var result = await _brandService.AddAsync(dto);
            return Ok(ResponseHelper.CreateResponse(result,MessageConstants.BRAND_CREATED_MESSAGE));

        }
        [HttpPost]
        [TypeFilter(typeof(ModelValidatorFilter<SearchModel>))]
        public async Task<IActionResult> GetBrandList(SearchModel searchModel)
        {
            var result = await _brandService.getBrandList(searchModel);
            return Ok(ResponseHelper.SuccessResponse(result, MessageConstants.DEFAULT_SUCCESS_MESSAGE));

        }
        [HttpPut]
        [TypeFilter(typeof(ModelValidatorFilter<BrandDto>))]
        [IdValidatorFilter]
        public async Task<IActionResult> UpdateBrand(long Id, BrandDto brandDto)
        {
             await _brandService.Update(brandDto,Id);
            return Ok(ResponseHelper.SuccessResponse(null, MessageConstants.BRAND_UPDATED_MESSAGE));

        }
        [HttpDelete]
        [IdValidatorFilter]
        public async Task<IActionResult> DeleteBrand(long Id)
        {
            return Ok(ResponseHelper.SuccessResponse(await _brandService.Remove(Id), MessageConstants.BRAND_DELETED_MESSAGE));

        }

    }
}
