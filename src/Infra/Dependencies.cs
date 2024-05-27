using Domain.Repositories.Database;
using Infra.Repositories;
using Infra.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Infra
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
            services.AddScoped<IClienteRepository, ClienteRepository>(sp =>
            {
                using (var scope = sp.CreateScope())
                {
                    var databaseConnectionFactory = scope.ServiceProvider.GetService<IDatabaseConnectionFactory>();                    
                    return new ClienteRepository(databaseConnectionFactory!);
                }
            });
            services.AddScoped<ICategoriaRepository, CategoriaRepository>(sp =>
            {
                using (var scope = sp.CreateScope())
                {
                    var databaseConnectionFactory = scope.ServiceProvider.GetService<IDatabaseConnectionFactory>();
                    return new CategoriaRepository(databaseConnectionFactory!);
                }
            });
            services.AddScoped<IProdutoRepository, ProdutoRepository>(sp =>
            {
                using (var scope = sp.CreateScope())
                {
                    var databaseConnectionFactory = scope.ServiceProvider.GetService<IDatabaseConnectionFactory>();
                    return new ProdutoRepository(databaseConnectionFactory!);
                }
            });
            services.AddScoped<IPedidoRepository, PedidoRepository>(sp =>
            {
                using (var scope = sp.CreateScope())
                {
                    var databaseConnectionFactory = scope.ServiceProvider.GetService<IDatabaseConnectionFactory>();
                    return new PedidoRepository(databaseConnectionFactory!);
                }
            });


            return services;
        }
    }
}
