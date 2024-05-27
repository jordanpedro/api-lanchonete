using Application.Common;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ApiLanchonete.Routes
{
    public static class RoutesProdutoExtension
    {
        const string route = "Produto";
        public static WebApplication AddRoutesProduto(this WebApplication app)
        {
            app.MapPost("/produto", async (Produto cliente, IProdutoServices produtoServices) =>
            {
                var resposta = await produtoServices.InsertAsync(cliente);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation) {
                Summary = "Id Categoria disponiveis =>\t 1 Lanche, 2 Acompanhamento, 3 Bebida, 4 Sobremesa",
                Description = "Id Categoria disponiveis =>\t 1 Lanche, 2 Acompanhamento, 3 Bebida, 4 Sobremesa",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapPut("/produto", async (Produto cliente, IProdutoServices produtoServices) =>
            {
                var resposta = await produtoServices.UpdateAsync(cliente);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation) {
                Summary = "Id Categoria disponiveis =>\t 1 Lanche, 2 Acompanhamento, 3 Bebida, 4 Sobremesa",
                Description = "Id Categoria disponiveis =>\t 1 Lanche, 2 Acompanhamento, 3 Bebida, 4 Sobremesa",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/produto/id/{id}", async (long id, IProdutoServices produtoServices) =>
            {
                var resposta = await produtoServices.GetAsync(id);
                return Results.Json(new Result<Produto>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca produto pelo id",
                Description = "Busca produto pelo id",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/produto/categoria/{id}", async (long id, IProdutoServices produtoServices) =>
            {
                var resposta = await produtoServices.GetByIdCategoriaAsync(id);
                return Results.Json(new Result<List<Produto>>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Id Categoria disponiveis =>\t 1 Lanche, 2 Acompanhamento, 3 Bebida, 4 Sobremesa",
                Description = "Id Categoria disponiveis =>\t 1 Lanche, 2 Acompanhamento, 3 Bebida, 4 Sobremesa",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/produto", async (IProdutoServices produtoServices) =>
            {
                var resposta = await produtoServices.GetAllAsync();
                return Results.Json(new Result<List<Produto>>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca todos os produtos",
                Description = "Busca todos os produtos",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapDelete("/produto/{id}", async (long id, IProdutoServices produtoServices) =>
            {
                var resposta = await produtoServices.DeleteAsync(id);

                var result = new Result<bool>()
                {
                    Sucesso = resposta,
                    Resposta = resposta,
                    Mensagem = resposta ? string.Empty : CommonConstants.MSG_DELETE_SEM_SUCESSO,
                    CodigoErro = resposta ? string.Empty : CommonConstants.CODE_DELETE_SEM_SUCESSO
                };

                return Results.Json(result);
            }).WithOpenApi(operation => new(operation) {
                Summary = "deleta um produto ",
                Description = "deleta um  produto ",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });


            return app;
        }
    }
}
