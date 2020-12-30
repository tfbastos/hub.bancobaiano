using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Banco.Baiano.SwaggerServices
{
    public static class SwaggerSecurity
    {

        public static IServiceCollection AddSwaggerSecurity(this IServiceCollection services, IConfiguration config)
        {
            
            var description = config.GetSection("AppConfigSwagger").GetSection("DescriptionAuth").Value;
            var title = config.GetSection("AppConfigSwagger").GetSection("Title").Value;
            var version = config.GetSection("AppConfigSwagger").GetSection("Version").Value;

            var teste = config.GetSection("AppConfigSwagger").GetSection("DescriptionAuth").Value;

            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = description

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                   new OpenApiSecurityScheme
                   {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                   },
                   new string[] {}
                   }
              });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = version });
            });

            return services;
        }
    }
}
