using management_system.Middleware;
using management_system.Repository.interfaces;
using management_system.Repository.Reposotories;
using management_system.Services.Interface;

namespace management_system.Configuration
{
    public static class RegisterRepositories
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository,BrandRepository>();
           
        }
    }
}
