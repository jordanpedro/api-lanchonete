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
using Application.Model.Response;

namespace ApiLanchonete.Routes
{
    public static class RoutesPedidoPagamentoExtension
    {
        public static WebApplication AddRoutesPedidoPagamento(this WebApplication app)
        {
        const string route = "Pagamento";

            app.MapPost("/pagamento/pedido/{idpedido}", async (PedidoFormaPagamentoModelRequest pedidoFormaPagamento, IPedidoFormaPagamentoServices pedidoPagamentoServices) =>
            {
                var resposta = await pedidoPagamentoServices.InsertAsync(pedidoFormaPagamento);
                return Results.Ok(new { StatusPagamentoAtualizado = resposta });
            }).WithOpenApi(operation => new(operation)
            {
                Summary = "Cria status do pagamento do pedido. Status: aprovado | reprovado \r\n IdFormaPagamento: 1 =>'Pix' | 2 =>'Cartao de credito (mastercard)' | 3 =>'Debito' | 4 =>'Cartao de credito (visa)' \r\n ",
                Description = "Cria status do pagamento do pedido. Status: aprovado | reprovado \r\n IdFormaPagamento: 1 =>'Pix' | 2 =>'Cartao de credito (mastercard)' | 3 =>'Debito' | 4 =>'Cartao de credito (visa)' \r\n ",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } }
            });

            app.MapGet("/pagamento/pedido/{idpedido}/status", async (long id, IPedidoFormaPagamentoServices pedidoPagamentoServices) =>
            {
                var resposta = await pedidoPagamentoServices.GetAsync(id);
                return Results.Json(new Result<PedidoFormaPagamentoResponse>() { Sucesso = resposta != null, Resposta = resposta });
            }).WithOpenApi(operation => new(operation) {
                Summary = "Busca status do pagamento de um pedido.",
                Description = "Busca status do pagamento de um pedido.",
                Tags = new List<OpenApiTag> { new OpenApiTag() { Name = route } } });

            return app;
        }
    }
}
