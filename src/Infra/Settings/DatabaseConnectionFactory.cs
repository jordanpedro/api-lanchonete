using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Settings
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection($"Data Source={Environment.GetEnvironmentVariable(InfraConstants.DB_HOST)},{Environment.GetEnvironmentVariable(InfraConstants.PORT_NUMBER)};User Id={Environment.GetEnvironmentVariable(InfraConstants.DB_USERNAME)}; Initial Catalog={Environment.GetEnvironmentVariable(InfraConstants.DB_NAME)}; Password={Environment.GetEnvironmentVariable(InfraConstants.DB_PASSWORD)}; TrustServerCertificate=True");
        }
    }
}
