using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PIS.DAL.DataModel;
using PIS.Repository;
using PIS.Repository.Automapper;
using PIS.Repository.Common;
using PIS.Service;
using PIS.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS.WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<PIS_DbContext>(options =>
			options.EnableSensitiveDataLogging().UseSqlServer(Configuration.GetConnectionString("PIS_DbConnection"),
			b => b.MigrationsAssembly("PIS.WebAPI")), ServiceLifetime.Singleton);

			services.AddScoped<IService, Service.Service>();

			services.AddSingleton<IRepository, Repository.Repository>();

			services.AddSingleton<IRepositoryMappingService, RepositoryMappingService>();

			services.AddCors();

			services.AddControllers();
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
