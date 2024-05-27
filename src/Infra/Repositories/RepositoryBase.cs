using DapperExtensions;
using Domain.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infra.Repositories
{
    public class RepositoryBase<T> : IBaseRepository<T> where T : class, new()
    {
        protected readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public RepositoryBase(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;            
        }
        public virtual async Task<bool> DeleteAsync(long id)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            var name = typeof(T).Name;
            var obj = await conn.ExecuteAsync($"DELETE FROM {name} WHERE Id = {id}");
            conn.Close();
            return obj > 0;
        }

        public virtual async Task<T> GetAsync(long id)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var obj = await conn.GetAsync<T>(id);
            conn.Close();
            return obj ?? new T();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            IEnumerable<T>? list = await conn.GetListAsync<T>();
            conn.Close();
            return list?.AsList() ?? new List<T>();
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var id = await conn.InsertAsync(entity);
            conn.Close();
            return id > 0;            
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            using var conn = _databaseConnectionFactory.GetConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var obj = await conn.UpdateAsync<T>(entity);
            conn.Close();
            return obj;
        }
    }
}
