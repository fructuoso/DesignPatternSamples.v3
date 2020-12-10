using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DesignPatternSamples.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using DesignPatternSamples.Domain.Core.Interfaces.Service;
using DesignPatternSamples.Domain.Services;
using DesignPatternSamples.Domain.Core.Interfaces.Repository;
using AutoMapper;
using System;
using FluentValidation.AspNetCore;

namespace WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesignPatternSamples", Version = "v1" });
            });
            #endregion

            #region DbContext
            services.AddDbContext<RepositoryContext>(options => options.UseInMemoryDatabase(databaseName: "TempDB"));
            #endregion

            #region Dependency Injectionn
            services.AddTransient(typeof(IServiceCrud<,>), typeof(GenericServiceCrud<,>));
            services.AddTransient(typeof(IRepositoryCrud<,>), typeof(GenericRepositoryCrud<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                ).AddFluentValidation(f => f.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });
            #endregion

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
