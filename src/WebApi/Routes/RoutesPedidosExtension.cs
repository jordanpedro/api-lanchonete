using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;
using Application.Services.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Common;
using Application.Model.Request;
using ApiLanchonete.Model.Response;

namespace ApiLanchonete.Routes
{
    public static class RoutesPedidosExtension
    {
        public static WebApplication AddRoutesPedido(this WebApplication app)
        {
        const string route = "Pedido";

            app.MapPost("/pedido", async (PedidoAgreggateModelRequest pedido, IPedidoServices pedidoServices) =>
            {
                var resposta = await pedidoServices.InsertAsync(pedido);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation)
            {
                Summary = "Cria pedido. O Cpf é opcional (valor null ou vazio) e o id do produto e sua quantidade deve ser informados.",
                Description = "Endpoint responsavel por criar pedido. O Cpf é opcional (valor null ou vazio) e o id do produto e sua quantidade deve ser informados.",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } }
            }); 

            app.MapPut("/pedido/{idpedido}/status/{status}", async (long idpedido, string status, IPedidoServices pedidoServices) =>
            {
                var resposta = await pedidoServices.UpdateStatusAsync( new PedidoAgreggateModelRequestUpdatStatus() { Status = status }, idpedido);
                return Results.NoContent();
            }).WithOpenApi(operation => new(operation)
            {
                Summary = "Muda status do pedido. Status possiveis: recebido, empreparacao, pronto, finalizado",
                Description = "Endpoint responsavel por mudar status do pedido.Status possiveis: recebido, empreparacao, pronto, finalizado",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } }
            });

            app.MapGet("/pedido/fila/{status}", async (string status, IPedidoServices pedidoServices) =>
            {
                var resposta = await pedidoServices.GetByStatusAsync(status);


                return Results.Json(new Result<List<PedidoAgreggateModelResponse>>() { Sucesso = resposta != null, Resposta = resposta });
            })
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Busca pedidos com base no status.Status possiveis: recebido, empreparacao, pronto, finalizado",
                Description = "Busca pedidos com base no status.Status possiveis: recebido, empreparacao, pronto, finalizado",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } }            
            });

            app.MapGet("/pedido/{id}", async (long id, IPedidoServices pedidoServices) =>
            {
                var resposta = await pedidoServices.GetAsync(id);
                return Results.Json(new Result<PedidoAgreggateModelResponse>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca pedido pelo id",
                Description = "Busca pedido pelo id",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            return app;
        }
    }
}
