using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Timelogger.BLL.DTO;
using TTimelogger.Api.DTOValidation;

namespace Timelogger.Api.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiConfiguration
            (this IServiceCollection services)
        {

            services.AddTransient<IValidator<Project>, ProjectValidator>();
            services.AddTransient<IValidator<ProjectTask>, ProjectTaskValidator>();
            return services;
        }
    }
}
