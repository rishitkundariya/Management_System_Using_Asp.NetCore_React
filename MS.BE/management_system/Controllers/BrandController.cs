using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using management_system.Filters;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using management_system.Entities.Dtos;

namespace management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase 
    {
        private  IValidator<BrandDto> _validator;
        public BrandController(IValidator<BrandDto> validator)
        {
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }
        [HttpPost]
        [TypeFilter(typeof(ModelValidatorFilter<BrandDto>))]
        public IActionResult GetBrand(BrandDto dto) {
            return Ok(dto);
        }

    }
}
