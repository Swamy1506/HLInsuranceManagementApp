using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HLInsuranceManagementApp.API.AuthExtensions;
using HLInsuranceManagementApp.API.Middleware;
using HLInsuranceManagementApp.Application;
using HLInsuranceManagementApp.Application.AutoMapperHelper;
using HLInsuranceManagementApp.Infrastructure;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using HLInsuranceManagementApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace HLInsuranceManagementApp.API
{
    public class Startup
    {
        private const string ApiName = "Loans API";
        private const string ApiVersion = "v1";
        private const string SwaggerEndpoint = "/swagger/v1/swagger.json";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperHelper));
            services.AddDbContext<HLIMDataContext>(opts => opts.UseSqlServer(this.Configuration.GetConnectionString("HLIMS")));
            services.AddAppServices();

            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddAzureAdBearer(options => Configuration.Bind("AzureAd", options));

            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo { Title = ApiName, Version = ApiVersion });
                //c.OperationFilter<AssignOAuth2SecurityRequirements>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMiddleware<ErrorHandlingMiddleware>();

            // loggerFactory.AddFile($"Logs/mylog-{DateTime.Now}.txt");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerEndpoint, ApiName);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyAllowSpecificOrigins");

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
