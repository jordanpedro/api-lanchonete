using Dapper;
using DapperExtensions;
using Domain.Entities;
using Domain.Repositories.Database;
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
            await conn.QueryAsync<PedidoAgreggate, Produto, ItemPedido, PedidoAgreggate>($"SELECT P.Id, P.IdCliente, P.DataCriacao, P.ValorTotal, P.Status, PP.Id As Id, PP.Nome, PP.ImagemUrl,ITP.Id as Id,ITP.IdProduto,ITP.IdPedido, ITP.Quantidade, ITP.DataCriacao FROM Pedido P INNER JOIN Itenspedido ITP ON P.id = ITP.IdPedido INNER JOIN Produto PP ON PP.Id = ITP.IdProduto LEFT JOIN Cliente C ON C.Id = P.idcliente WHERE [Status] = '{status}'",
                (pedido, produto,item) =>
                {
                    if(!lista.Any(p => p.Id == pedido.Id))
                    {
                        lista.Add(pedido);
                    }
                    if (item is not null)
                    {
                        var pedidoaux = lista.FirstOrDefault(p => p.Id == pedido.Id);
                        if (pedidoaux is not null)
                            pedidoaux.ItensPedido.Add(item);
                    }
                    return pedido;
                },
                splitOn: "Id,Id");
            conn.Close();
            return lista?.AsList() ?? new List<PedidoAgreggate>();
        }
        public override async Task<PedidoAgreggate> GetAsync(long id)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var obj = await conn.GetAsync<PedidoAgreggate>(id);
            conn.Close();
            return obj ?? new PedidoAgreggate(); 
        }
        public override async Task<bool> InsertAsync(PedidoAgreggate entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var id = await conn.InsertAsync(entity);
            conn.Close();
            return id > 0;
        }
    }
}
