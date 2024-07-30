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
    public class PedidoFormaPagamentoRepository : RepositoryBase<PedidoFormaPagamento>, IPedidoFormaPagamentoRepository
    {
        public PedidoFormaPagamentoRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {
        }
        public override async Task<PedidoFormaPagamento> GetAsync(long id)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model =  await conn.QueryFirstAsync<PedidoFormaPagamentoModel>($"SELECT Id, IdPedido, Status, IdFormaPagamento FROM PedidoFormaPagamento where IdPedido = {id}");
            conn.Close();
            var entity = new PedidoFormaPagamento()
            {
                FormaPagamento = new FormaPagamento { Id = model.IdFormaPagamento },
                Pedido = new PedidoAgreggate() { Id = model.IdPedido },
                Id = model.Id,
                Status = model.Status
            };
            return entity ?? new PedidoFormaPagamento(); 
        }
        public override async Task<bool> InsertAsync(PedidoFormaPagamento entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = PedidoFormaPagamentoModel.FromEntityToModelInInsert(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id > 0;
        }
    }
}
