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
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {            
        }
        public async Task<Cliente> GetByCpfAsync(string cpf)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var obj = await conn.QueryFirstOrDefaultAsync<ClienteModel>($"SELECT * FROM Cliente WHERE Cpf = '{cpf}' ");
            conn.Close();
            return ClienteModel.FromModelToEntity(obj) ?? new ();
        }

        public override async Task<bool> InsertAsync(Cliente entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = ClienteModel.FromEntityToModel(entity);
            var id = await conn.InsertAsync(model);
            conn.Close();
            return id > 0;
        }
        public override async Task<bool> UpdateAsync(Cliente entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var model = ClienteModel.FromEntityToModel(entity);
            var retorno = await conn.UpdateAsync(model);
            conn.Close();
            return retorno;
        }
        public override async Task<List<Cliente>> GetAllAsync()
        {
            List<Cliente> listCliente = new List<Cliente>();
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IEnumerable<ClienteModel>? list = await conn.GetListAsync<ClienteModel>();
            conn.Close();

            if (list != null && list.Any())
            {
                foreach (var item in list)
                    listCliente.Add(ClienteModel.FromModelToEntity(item));
            }
            return listCliente?.AsList() ?? new List<Cliente>();
        }
        public override async Task<Cliente> GetAsync(long idcategoria)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            ClienteModel? cat = await conn.GetAsync<ClienteModel>(idcategoria);
            conn.Close();
            var ret = ClienteModel.FromModelToEntity(cat);
            return ret ?? new();
        }
    }
}
