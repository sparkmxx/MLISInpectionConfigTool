using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace RedNoble.Inspection.Integration.Oracle
{
    public static class ConnectionFactory
    {
        public static IDbConnection Create()
        {
            var conn= new OracleConnection(ConfigurationManager.AppSettings["lis"]);
            conn.Open();
            return conn;
        }
    }
}