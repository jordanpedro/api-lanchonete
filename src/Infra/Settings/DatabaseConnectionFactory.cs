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
            return new SqlConnection(Environment.GetEnvironmentVariable(InfraConstants.CONNECTION_STRING));
        }
    }
}
