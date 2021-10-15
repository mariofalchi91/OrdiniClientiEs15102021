using Core.Interfacce;
using EntityFramework;
using EntityFramework.Repos;
using GestioneOrdiniClienti;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace WebApi
{
    public class Startup
    {
        public string ApplicationName = Assembly.GetEntryAssembly().GetName().Name;
        public string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection s)
        {
            s.AddControllers();

            // dependency injection
            s.AddTransient<IBusinessLayer, BusinessLayer>();
            s.AddTransient<IOrdineRepository, EFOrdineRepository>();
            s.AddTransient<IClienteRepository, EFClienteRepository>();

            // config ef core
            s.AddDbContext<Context>(options=>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AcademyG"));
            }
            );

            // config swagger
            s.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json",
                    $"{ApplicationName} {ApplicationVersion}");
            });

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
