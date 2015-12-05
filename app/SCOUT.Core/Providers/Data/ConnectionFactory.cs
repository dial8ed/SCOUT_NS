using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    public static class ConnectionFactory
    {        
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(Helpers.CnnStr());
        }        
    }
}