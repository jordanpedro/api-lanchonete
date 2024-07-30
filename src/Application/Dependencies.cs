using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IProdutoServices, ProdutoServices>();
            services.AddScoped<ICategoriaServices, CategoriaServices>();
            services.AddScoped<IPedidoServices, PedidoServices>();
            services.AddScoped<IPedidoFormaPagamentoServices, PedidoFormaPagamentoServices>();
            return services;
        }
    }
}
