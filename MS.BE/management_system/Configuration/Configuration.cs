using management_system.Entities.DataModels;
using management_system.Middleware;
using Microsoft.EntityFrameworkCore;

namespace management_system.Configuration
{
    public static class Configuration
    {
        public static void RegisterContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AppDbContext")));
            services.AddTransient<ExceptionMiddleware>();
        }
        public static void RegisterMiddleware(this IServiceCollection services)
        {

            services.AddTransient<ExceptionMiddleware>();
        }
    }
}
