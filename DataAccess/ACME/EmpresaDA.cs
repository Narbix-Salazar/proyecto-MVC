using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Models.ACME;

namespace DataAccess.ACME
{
    public class EmpresaDA
    { 
        private Conexion _conexion = new Conexion();
        public void Insertar(EmpresaEntidad empresaEntidad)
        {
            SqlConnection sqlconn = _conexion.conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "InsertarEmpresa";
                sqlcomm.Parameters.Add(new SqlParameter("@IDEmpresa", SqlDbType.Int)).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add(new SqlParameter("@IDTipoEmpresa", empresaEntidad.IDTipoempresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Empresa", empresaEntidad.empresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Direccion", empresaEntidad.direccion));
                sqlcomm.Parameters.Add(new SqlParameter("@RUC", empresaEntidad.RUC));
                sqlcomm.Parameters.Add(new SqlParameter("@FechaCreacion", empresaEntidad.fechacreacion));
                sqlcomm.Parameters.Add(new SqlParameter("@Presupuesto", empresaEntidad.presupuesto));
                sqlcomm.Parameters.Add(new SqlParameter("@Activo", empresaEntidad.activo));

                sqlcomm.ExecuteNonQuery();
                empresaEntidad.IDempresa = (int)sqlcomm.Parameters[sqlcomm.Parameters.IndexOf("IDempresa")].Value;

                sqlconn.Close();
            }
            catch (Exception ex) 
            {
                throw new Exception("EmpresaDA.Insertar: " + ex.Message);
            }
            finally
            { sqlconn.Dispose(); 
            }
        }
        public void Modificar(EmpresaEntidad empreseEntidad)
        {
            SqlConnection sqlconn = _conexion.conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "ModicarEmpresa";
                sqlcomm.Parameters.Add(new SqlParameter("@IDEmpresa", empreseEntidad.IDempresa));
                sqlcomm.Parameters.Add(new SqlParameter("@IDTipoEmpresa", empreseEntidad.IDTipoempresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Empresa", empreseEntidad.empresa));
                sqlcomm.Parameters.Add(new SqlParameter("@Direccion", empreseEntidad.direccion));
                sqlcomm.Parameters.Add(new SqlParameter("@RUC", empreseEntidad.RUC));
                sqlcomm.Parameters.Add(new SqlParameter("@FechaCreacion", empreseEntidad.fechacreacion));
                sqlcomm.Parameters.Add(new SqlParameter("@Presupuesto", empreseEntidad.presupuesto));
                sqlcomm.Parameters.Add(new SqlParameter("@Activo", empreseEntidad.activo));

                if(sqlcomm.ExecuteNonQuery() !=1)
                {
                    throw new Exception("EmpresaDA.Modificar: Preoblema al actualizar.");
                }
                
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Modificar: " + ex.Message);
            }
            finally
            {
                sqlconn.Dispose();
            }
        }

        public void Anular(EmpresaEntidad empreseEntidad)
        {
            SqlConnection sqlconn = _conexion.conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "AnularEmpresa";
                sqlcomm.Parameters.Add(new SqlParameter("@IDEmpresa", empreseEntidad.IDempresa));


                sqlcomm.ExecuteNonQuery();

                sqlconn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Anular: " + ex.Message);
            }
            finally
            {
                sqlconn.Dispose();
            }
        }
         public List<EmpresaEntidad> Listar()
        {
            SqlConnection sqlconn = _conexion.conectar();
            SqlDataReader sqlDataReader;
            SqlCommand sqlcomm = new SqlCommand();

            List<EmpresaEntidad>? listaEmpresas = new List<EmpresaEntidad>();
            EmpresaEntidad? empresaEntidad;

            try
            {
                sqlconn.Open();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "ListarEmpresa";
                sqlDataReader = sqlcomm.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    empresaEntidad = new();
                    empresaEntidad.IDempresa = (int)sqlDataReader["IDempresa"];
                    empresaEntidad.empresa = sqlDataReader["empresa"].ToString() ?? string.Empty;
                    empresaEntidad.direccion = sqlDataReader["Direciion"].ToString() ?? string.Empty;
                    empresaEntidad.RUC = sqlDataReader["RUC"].ToString() ?? string.Empty;
                    if (sqlDataReader["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntidad.fechacreacion = (DateTime)sqlDataReader["FechaCreacion"];
                    }
                    if (sqlDataReader["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntidad.presupuesto = (decimal)sqlDataReader["Presupuesto"];
                    }
                    empresaEntidad.activo = (bool)sqlDataReader["Activo"];

                    listaEmpresas.Add(empresaEntidad);
                }

                sqlconn.Close();

                return listaEmpresas;
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Listar: " + ex.Message);
            }
            finally
            {
                sqlconn.Dispose();
            }
        }

        public EmpresaEntidad BuscarID(int IDEmpresa)
        {
            // Obtener una instancia de la conexion
            SqlConnection sqlConn = _conexion.conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            EmpresaEntidad? empresaEntidad = null;

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "BuscarEmpresa";

                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", IDEmpresa));

                sqlDataRead = sqlComm.ExecuteReader();

                while (sqlDataRead.Read())
                {
                    empresaEntidad = new();
                    empresaEntidad.IDempresa = (int)sqlDataRead["IDEmpresa"];
                    empresaEntidad.IDTipoempresa = (int)sqlDataRead["IDTipoEmpresa"];
                    empresaEntidad.empresa = sqlDataRead["Empresa"].ToString() ?? string.Empty;
                    empresaEntidad.direccion = sqlDataRead["Direciion"].ToString() ?? string.Empty;
                    empresaEntidad.RUC = sqlDataRead["RUC"].ToString() ?? string.Empty;
                    if (sqlDataRead["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntidad.fechacreacion = (DateTime)sqlDataRead["FechaCreacion"];
                    }
                    if (sqlDataRead["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntidad.presupuesto = (decimal)sqlDataRead["Presupuesto"];
                    }
                    empresaEntidad.activo = (bool)sqlDataRead["Activo"];


                }

                sqlConn.Close();

                if (empresaEntidad == null)
                {
                    throw new Exception("EmpresaDA.BusacrID: El ID de empresa no existe");
                }

                return empresaEntidad;
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.BuscarID: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
    }
}