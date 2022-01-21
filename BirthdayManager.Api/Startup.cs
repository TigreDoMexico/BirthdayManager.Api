using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayManager.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;


namespace BirthdayManager.Api
{
    [ExcludeFromCodeCoverage]
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
            services.AddControllers();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthdayManager.Api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.AddGraphQLServer();

            services.AddScoped<ContextDomain>();
            services.AddScoped<BirthdayDomain>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BirthdayManager.Api v1"));

                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }


    }
}
