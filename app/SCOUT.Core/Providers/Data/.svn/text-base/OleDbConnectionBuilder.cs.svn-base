using System.Data.OleDb;

namespace SCOUT.Core.Data
{
    public static class OleDbConnectionBuilder
    {
        public static OleDbConnection CreateConnection(string provider, string dataSource, string extendedProperties)
        {
            string connectionString =
                "Provider={0};Data Source={1};Extended Properties={2}";

            extendedProperties =
                Strings.WrapInDoubleQuotes(extendedProperties);

            connectionString = string.Format(connectionString, provider,
                                             dataSource, extendedProperties);

            OleDbConnection connection = new OleDbConnection(connectionString);

            return connection;

        }
    }
}