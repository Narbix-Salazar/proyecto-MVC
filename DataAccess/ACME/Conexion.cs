using Microsoft.Data.SqlClient;

namespace DataAccess.ACME
{
    public class Conexion
    {
        private readonly string? _cadenaConexion;

        public Conexion()
        {
            string? cadenaConxion;
            cadenaConxion = Environment.GetEnvironmentVariable("SQLServerXE");
            _cadenaConexion = cadenaConxion;

        }
        public SqlConnection conectar()
        {
            SqlConnection sqlconn;
            sqlconn = new SqlConnection(_cadenaConexion);
            return sqlconn; 

        }
    }
}
