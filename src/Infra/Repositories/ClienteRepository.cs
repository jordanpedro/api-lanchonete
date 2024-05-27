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
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public ClienteRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<Cliente> GetByCpfAsync(string cpf)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var obj = await conn.QueryFirstOrDefaultAsync<Cliente>($"SELECT * FROM Cliente WHERE Cpf = '{cpf}' ");
            conn.Close();
            return obj ?? new ();
        }
    }
}
