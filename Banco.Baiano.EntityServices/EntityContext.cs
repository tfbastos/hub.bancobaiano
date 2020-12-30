using Banco.Baiano.Context;
using Banco.Baiano.Interface;
using Banco.Baiano.Model;
using Banco.Baiano.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Banco.Baiano.EntityServices
{
    public static class EntityContext
    {

        public static IServiceCollection AddMyContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MyContext>(options => {
                //options.UseNpgsql(config.GetSection("ConnectionStrings").GetSection("Default").Value);
                options.UseSqlServer(config.GetSection("ConnectionStrings").GetSection("GuearHost").Value);
            });

            services.AddTransient<IRepository<Cliente>, MyRepository<Cliente>>();
            services.AddTransient<IRepository<Contrato>, MyRepository<Contrato>>();
            services.AddTransient<IRepository<SituacaoContrato>, MyRepository<SituacaoContrato>>();
            services.AddTransient<IRepository<Parcela>, MyRepository<Parcela>>();
            services.AddTransient<IRepository<Negociacao>, MyRepository<Negociacao>>();

            return services;
        }
    }
}
