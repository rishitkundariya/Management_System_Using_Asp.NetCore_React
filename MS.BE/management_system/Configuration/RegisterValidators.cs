using FluentValidation;
using management_system.Entities.Dtos;
using management_system.Entities.Validator;
using management_system.Filters;
using management_system.Repository.Reposotories;
using management_system.Services.Interface;

namespace management_system.Configuration
{
    public static class RegisterValidators
    {
        public static void RegisterValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BrandDto>, BrandDtoValidator>();
            services.AddScoped(typeof(ModelValidatorFilter<>));
        }
    }
}
