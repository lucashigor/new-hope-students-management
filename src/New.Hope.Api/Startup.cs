using System.Text.Json;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using New.Hope.Api.Configuration;
using New.Hope.Kernel;
using Newtonsoft.Json.Serialization;

namespace New.Hope.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public IWebHostEnvironment CurrentEnviroment { get; }

		public Startup(IWebHostEnvironment env)
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(env.ContentRootPath)
					.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
					.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
					.AddEnvironmentVariables();

			CurrentEnviroment = env;

			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddMvc()
					.AddJsonOptions(jo =>
					{
						jo.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
						jo.JsonSerializerOptions.IgnoreNullValues = true;
					}).AddFluentValidation();

			services.ResolveDependencyInjectionConfig();
			services.ResolveFluentValidationsInjectionConfigs();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
