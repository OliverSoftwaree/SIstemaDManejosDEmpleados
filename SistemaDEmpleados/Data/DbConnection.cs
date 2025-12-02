using System.Data.SqlClient;

namespace SistemaDEmpleados.Data
{
    public static class DbConnection
    {
        // Cadena de conexión para LocalDB
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmpleadosDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}