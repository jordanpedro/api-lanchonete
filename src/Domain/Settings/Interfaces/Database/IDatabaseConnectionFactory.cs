using System.Data;
using System.Data.SqlClient;

public interface IDatabaseConnectionFactory
{
    IDbConnection GetConnection();
}

