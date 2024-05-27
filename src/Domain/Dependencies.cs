using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Domain
{
    public static class Dependencies
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {            
            return services;
        }
    }
}
