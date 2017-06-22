using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RedNoble.Inspection.Integration.Sql
{
    public static class ConnectionFactory
    {
        public static IDbConnection Create()
        {
            var conn= new SqlConnection(ConfigurationManager.AppSettings["lis"]);
            conn.Open();
            return conn;
        }
    }
}