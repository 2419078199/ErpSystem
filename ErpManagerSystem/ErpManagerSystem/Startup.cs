using System;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using AutoMapper;
using ErpManagerSystem.Ext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model.Entitys;
using Swashbuckle.AspNetCore.Filters;

namespace ErpManagerSystem
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<DB_ERPContext>(Configure =>
            {
                Configure.UseSqlServer(_configuration.GetConnectionString("default"));
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Description = "ErpMAnagerSystemApi",
                    Contact = new OpenApiContact()
                    {
                        Name = "EroManagerSystem"
                    },
                    Title = "EroManagerSystem"
                });
                setup.OperationFilter<AddResponseHeadersFilter>();
                setup.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                setup.OperationFilter<SecurityRequirementsOperationFilter>();
                setup.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Description = "请输入accessToken"
                });
                //setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ErpManagerSystem.xml"), true);
            });
            services.AddAuthentication(configureOptions =>
            {
                configureOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = nameof(ApiResponseHandler);
                configureOptions.DefaultForbidScheme = nameof(ApiResponseHandler);
            }).AddJwtBearer(configure =>
            {
                configure.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Authentication:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Authentication:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SigningKey"])),
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromDays(7),
                    ValidateLifetime = true
                };
            }).AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { }); ;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = "";
                setup.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            string basePath = AppContext.BaseDirectory;
            Assembly servicesAssembly = Assembly.LoadFrom(Path.Combine(basePath, "Services.dll"));
            Assembly repositoryAssembly = Assembly.LoadFrom(Path.Combine(basePath, "Repository.dll"));
            //注入Services程序集
            containerBuilder.RegisterAssemblyTypes(servicesAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //注入Repository程序集
            containerBuilder.RegisterAssemblyTypes(repositoryAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
