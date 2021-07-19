using Timelogger.BLL.Services;
using Timelogger.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Timelogger.BLL.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBllConfiguration
            (this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectTaskService, ProjectTaskService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
