using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Timelogger.Api.ExceptionHandler;
using Timelogger.BLL.Dependencies;
using Timelogger.DAL.Dependencies;
using FluentValidation.AspNetCore;
using FluentValidation;
using TTimelogger.Api.DTOValidation;
using Timelogger.DAL.Base;
using Timelogger.BLL.DTO;
using Timelogger.Api.Dependencies;

namespace Timelogger.Api
{
	public class Startup
	{
		private readonly IWebHostEnvironment _environment;
		public IConfigurationRoot Configuration { get; }

		public Startup(IWebHostEnvironment env)
		{
			_environment = env;

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            // Add framework services.
            services.AddControllers(opt => opt.Filters.Add(new ExceptionHandlingFilter()));

            services.AddDalConfiguration(Configuration);

			services.AddBllConfiguration();
			
			services.AddLogging(builder =>
			{
				builder.AddConsole();
				builder.AddDebug();
			});

			services.AddSwaggerGen();

			services.AddMvc(options => options.EnableEndpointRouting = false).AddFluentValidation();

			services.AddApiConfiguration();

			if (_environment.IsDevelopment())
			{
				services.AddCors();
			}
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseCors(builder => builder
					.AllowAnyMethod()
					.AllowAnyHeader()
					.SetIsOriginAllowed(origin => true)
					.AllowCredentials());
			}

			app.UseMvc();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Timelogger API V1");
				c.RoutePrefix = string.Empty;
			});

			var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using var scope = serviceScopeFactory.CreateScope();
            SeedDatabase(scope);
        }

		private static void SeedDatabase(IServiceScope scope)
		{
			var context = scope.ServiceProvider.GetService<TimeloggerContext>();
			TimeloggerContextSeeder.Seed(context);
		}
	}
}