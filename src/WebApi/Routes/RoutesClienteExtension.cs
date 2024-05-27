using Application.Common;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ApiLanchonete.Routes
{
    public static class RoutesClienteExtension
    {
        public static WebApplication AddRoutesCliente(this WebApplication app)
        {
            const string route = "Cliente";

            app.MapPost("/cliente", async (Cliente cliente,  IClienteServices clienteServices) =>
            {
               var resposta = await clienteServices.InsertAsync(cliente);
               return Results.NoContent();
            }).WithOpenApi(operation => new(operation) {
                Summary = "Cria um cliente",
                Description = "Cria um cliente",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapPut("/cliente", async (Cliente cliente, IClienteServices clienteServices) =>
            {
                var resposta = await clienteServices.UpdateAsync(cliente);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation) {
                Summary = "Atualiza cliente",
                Description = "Atualiza cliente",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/cliente/id/{id}", async (long id, IClienteServices clienteServices) =>
            {
                var resposta = await clienteServices.GetAsync(id);
                return Results.Json(new Result<Cliente>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca cliente pelo id",
                Description = "Busca cliente pelo id",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/cliente/{cpf}", async (string cpf, IClienteServices clienteServices) =>
            {
               var resposta = await clienteServices.GetByCpfAsync(cpf);
                return Results.Json(new Result<Cliente>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca um produto por cpf",
                Description = "Busca um  produto por cpf",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/cliente", async (IClienteServices clienteServices) =>
            {
                var resposta = await clienteServices.GetAllAsync();
                return Results.Json(new Result<List<Cliente>>() { Sucesso = resposta != null , Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {Summary = "Busca uma lista de clientes", Description = "Busca uma lista de clientes", Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapDelete("/cliente/{id}", async (long id, IClienteServices clienteServices) =>
            {
                var resposta = await clienteServices.DeleteAsync(id);

                var result = new Result<bool>()
                {
                    Sucesso =  resposta,
                    Resposta = resposta,
                    Mensagem = resposta ? string.Empty: CommonConstants.MSG_DELETE_SEM_SUCESSO,
                    CodigoErro = resposta ? string.Empty : CommonConstants.CODE_DELETE_SEM_SUCESSO
                };

                return Results.Json(result);
            }).WithOpenApi(operation => new(operation) {
                Summary = "deleta um produto",
                Description = "deleta um  produto",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            return app;
        }
    }
}
