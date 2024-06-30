using management_system.Services.Interface;
using management_system.Services.Services;

namespace management_system.Configuration
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
        }
    }
}
