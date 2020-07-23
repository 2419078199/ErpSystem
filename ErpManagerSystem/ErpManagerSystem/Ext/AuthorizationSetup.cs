using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ErpManagerSystem.Ext
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services, IConfiguration _configuration)
        {
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
                    ClockSkew = TimeSpan.FromMinutes(30),
                    ValidateLifetime = true
                };
            }).AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });
        }
    }
}