using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;

namespace ErpManagerSystem.Ext
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Description = "ErpManagerSystemApi",
                    Contact = new OpenApiContact()
                    {
                        Name = "ErpManagerSystem"
                    },
                    Title = "ErpManagerSystem"
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
                setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ErpManagerSystem.xml"), true);
            });
        }
    }
}