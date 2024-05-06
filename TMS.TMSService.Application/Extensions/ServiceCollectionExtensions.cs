using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TMS.TMSService.Application.Interfaces;

namespace TMS.TMSService.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

