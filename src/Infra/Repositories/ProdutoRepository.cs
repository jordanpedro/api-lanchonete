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
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDatabaseConnectionFactory databaseConnectionFactory) : base(databaseConnectionFactory)
        {
        }
        public async Task<List<Produto>> GetByIdCategoriaAsync(long id)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IEnumerable<Produto>? list = await conn.QueryAsync<Produto>($"SELECT * FROM Produto WHERE IdCategoria = {id}"); 
            conn.Close();
            return list?.ToList() ?? new List<Produto>();
        }
    }
}
