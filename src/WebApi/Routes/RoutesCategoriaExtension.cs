
using ApiLanchonete.Model.Response;
using Application.Common;
using Application.Model.Request;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ApiLanchonete.Routes
{
    public static class RoutesCategoriaExtension
    {
        const string route = "Categoria";
        public static WebApplication AddRoutesCategoria(this WebApplication app)
        {
            app.MapPost("/categoria", async (CategoriaModelRequest categoria, ICategoriaServices categoriaServices) =>
            {
                var resposta = await categoriaServices.InsertAsync(categoria);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation) {
                Summary = "Cria categoria",
                Description = "Cria nova categoria",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapPut("/categoria/{idcategoria}", async (CategoriaModelRequest categoria, long idcategoria, ICategoriaServices categoriaServices) =>
            {
                var resposta = await categoriaServices.UpdateAsync(categoria, idcategoria);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation) {
                Summary = "Atualiza Categoria",
                Description = "Atualiza Categoria",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/categoria/{id}", async (long id, ICategoriaServices categoriaServices) =>
            {
                var resposta = await categoriaServices.GetAsync(id);
                return Results.Json(new Result<CategoriaModelResponse>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca uma Categoria",
                Description = "Busca uma Categoria",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapGet("/categoria", async (ICategoriaServices categoriaServices) =>
            {
                var resposta = await categoriaServices.GetAllAsync();
                return Results.Json(new Result<List<CategoriaModelResponse>>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca todas as Categorias",
                Description = "Busca todas as Categorias",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            app.MapDelete("/categoria/{id}", async (long id, ICategoriaServices categoriaServices) =>
            {
                var resposta = await categoriaServices.DeleteAsync(id);

                var result = new Result<bool>()
                {
                    Sucesso = resposta,
                    Resposta = resposta,
                    Mensagem = resposta ? string.Empty : CommonConstants.MSG_DELETE_SEM_SUCESSO,
                    CodigoErro = resposta ? string.Empty : CommonConstants.CODE_DELETE_SEM_SUCESSO
                };

                return Results.Json(result);
            }).WithOpenApi(operation => new(operation) {
                Summary = "deleta uma Categoria", 
                Description = "deleta uma Categoria", 
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            return app;
        }
    }
}
