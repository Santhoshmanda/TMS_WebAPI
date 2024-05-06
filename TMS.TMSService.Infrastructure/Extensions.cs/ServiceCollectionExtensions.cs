using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TMS.TMSService.Domain.Interfaces;
using TMS.TMSService.Infrastructure.Persistance;
using TMS.TMSService.Infrastructure.Repositories;

namespace TMS.TMSService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TMSContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbContext") ?? "")
                    .EnableSensitiveDataLogging());
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

