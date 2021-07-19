using Timelogger.DAL.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Timelogger.DAL.UnitOfWork;
using System;

namespace Timelogger.DAL.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalConfiguration
            (this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<TimeloggerContext>(opt =>
            //opt.UseLazyLoadingProxies().
            //UseSqlServer(configuration.
            //GetConnectionString("TimeLogger")));

            services.AddDbContext<TimeloggerContext>(opt => opt.UseLazyLoadingProxies().UseInMemoryDatabase("TimeLogger"));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
