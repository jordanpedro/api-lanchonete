using ApiLanchonete.Routes;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;
using Infra;
using Application;
using Domain;
using ApiLanchonete.Middleware;

namespace ApiLanchonete
{
    public static class Dependencies
    {
        internal static IServiceCollection BuildServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwagger();
            services.AddApplication(configuration);
            services.AddDomain(configuration);
            services.AddInfrastructure(configuration);
            
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(config =>
            {
                config.CustomSchemaIds(type => type.ToString());

                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Lanchonete",
                    Version = "v1",
                    Description = "Projeto Lanchonete v1"
                });
            });

            return services;
        }

        internal static WebApplication UseServices(this WebApplication app, IWebHostEnvironment env)
        {

            app.UseSwaggerCustom();
            app.UseCustomExceptionHandler();
            AddAllRoutes(app);

            return app;
        }

        internal static WebApplication AddAllRoutes(this WebApplication app)
        {
            app.AddRoutesCliente();
            app.AddRoutesCategoria();
            app.AddRoutesPedido();
            app.AddRoutesProduto();
            return app;
        }

        internal static WebApplication UseSwaggerCustom(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Lanchonete"));
            return app;
        }
    }
}
