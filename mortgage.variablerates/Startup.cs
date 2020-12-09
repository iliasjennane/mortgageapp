using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace mortgage.variablerates
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

            services.AddControllers();
            services.AddApiVersioning(
                options => {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(1,0);
                }
            );
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(
                    descriptions => {
                        return descriptions.First();
                    }
                );
                c.SwaggerDoc("1.0", new OpenApiInfo { Title = "Variable rates mortgage API", Version = "1.0" });
                c.SwaggerDoc("2.0", new OpenApiInfo { Title = "Variable rates mortgage API", Version = "2.0" });
                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
               
            app.UseSwaggerUI(c => {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "Variable rates mortgage API 1.0");
                c.SwaggerEndpoint("/swagger/2.0/swagger.json", "Variable rates mortgage API 2.0");
                //c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                
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
