using Dapper;
using DapperExtensions;
using Domain.Entities;
using Domain.Repositories.Database;
using Infra.Model;
using Infra.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PedidoRepository : RepositoryBase<PedidoAgreggate>, IPedidoRepository
    {
        public PedidoRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {
        }
        public async Task<bool> UpdateStatusAsync(PedidoAgreggate pedido)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var obj = await conn.ExecuteAsync($"UPDATE Pedido set Status = '{pedido.Status}' Where Id = {pedido.Id}");
            conn.Close();
            return obj > 0;
        }
        public async Task<List<PedidoAgreggate>> GetByStatusAsync(string status)
        {
            List<PedidoAgreggate> lista = new List<PedidoAgreggate>();

            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            await conn.QueryAsync<PedidoAgreggate, Produto, ItemPedido, Categoria, Cliente, PedidoAgreggate>($"  SELECT P.Id, P.DataCriacao, P.ValorTotal, P.Status, PP.Id As Id, PP.Nome, PP.ImagemUrl, PP.Preco, ITP.Id, ITP.Quantidade, ITP.DataCriacao, Cat.Id, Cat.Nome, C.Id, C.Nome, C.Cpf FROM Pedido P INNER JOIN Itenspedido ITP ON P.id = ITP.IdPedido INNER JOIN Produto PP ON PP.Id = ITP.IdProduto INNER JOIN Categoria Cat ON Cat.Id = PP.IdCategoria LEFT JOIN Cliente C ON C.Id = P.idcliente WHERE [Status] =  '{status}'",
                (pedido, produto,item, categoria, cliente) =>
                {
                    if(!lista.Any(p => p.Id == pedido.Id))
                    {
                        lista.Add(pedido);
                    }
                    if (item is not null)
                    {
                        var pedidoaux = lista.FirstOrDefault(p => p.Id == pedido.Id);
                        if (pedidoaux is not null)
                        {
                            pedidoaux.Cliente = cliente;

                            Produto prod = new Produto
                            {
                                Id = produto.Id,
                                ImagemUrl = produto.ImagemUrl,
                                Nome = produto.Nome,
                                Preco = produto.Preco,
                                DataCriacao = produto.DataCriacao,
                                Categoria = categoria
                            };
                            item.Produto = prod;
                            pedidoaux?.ItensPedido?.Add(item);
                        }
                    }
                    return pedido;
                },
                splitOn: "Id,Id,Id,Id");
            conn.Close();
            return lista?.AsList() ?? new List<PedidoAgreggate>();
        }
        public override async Task<PedidoAgreggate> GetAsync(long id)
        {
            PedidoAgreggate pedidoRetorno = default;

            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            await conn.QueryAsync<PedidoAgreggate, Produto, ItemPedido, Categoria, Cliente, PedidoAgreggate>($"  SELECT P.Id, P.DataCriacao, P.ValorTotal, P.Status, PP.Id As Id, PP.Nome, PP.ImagemUrl, PP.Preco, ITP.Id, ITP.Quantidade, ITP.DataCriacao, Cat.Id, Cat.Nome, C.Id, C.Nome, C.Cpf FROM Pedido P INNER JOIN Itenspedido ITP ON P.id = ITP.IdPedido INNER JOIN Produto PP ON PP.Id = ITP.IdProduto INNER JOIN Categoria Cat ON Cat.Id = PP.IdCategoria LEFT JOIN Cliente C ON C.Id = P.idcliente WHERE P.Id = {id}",
                (pedido, produto, item, categoria, cliente) =>
                {
                    if (item is not null)
                    {
                        if (pedidoRetorno is null)
                            pedidoRetorno = pedido;

                        pedidoRetorno.Cliente = cliente;

                            Produto prod = new Produto
                            {
                                Id = produto.Id,
                                ImagemUrl = produto.ImagemUrl,
                                Nome = produto.Nome,
                                Preco = produto.Preco,
                                DataCriacao = produto.DataCriacao,
                                Categoria = categoria
                            };
                            item.Produto = prod;
                        pedidoRetorno?.ItensPedido?.Add(item);
                    }
                    return pedido;
                },
                splitOn: "Id,Id,Id,Id");
            conn.Close();
            return pedidoRetorno ?? new PedidoAgreggate(); 
        }
        public override async Task<bool> InsertAsync(PedidoAgreggate entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = PedidoAgreggateModel.FromEntityToModelInInsert(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id > 0;
        }
        public async Task<long> InsertWithReturnIdAsync(PedidoAgreggate entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = PedidoAgreggateModel.FromEntityToModelInInsert(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id;
        }
        public async Task<long> InsertItensAsync(ItemPedido entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = ItemPedidoModel.FromEntityToModel(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id;
        }
    }
}
