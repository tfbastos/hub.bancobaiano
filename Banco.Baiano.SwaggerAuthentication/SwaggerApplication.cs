using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Banco.Baiano.SwaggerServices
{
    public static class SwaggerApplication
    {

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration config)
        {
            var route = config.GetSection("AppConfigSwagger").GetSection("RouteTemplate").Value;
            var endpoint = config.GetSection("AppConfigSwagger").GetSection("Endpoint").Value;
            var name = config.GetSection("AppConfigSwagger").GetSection("Name").Value;


            app.UseSwagger(c =>
            {
                c.RouteTemplate = route;          
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(endpoint, name);
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);              
            });

            return app;
        }
    }
}
