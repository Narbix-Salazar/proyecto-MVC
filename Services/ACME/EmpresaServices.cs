using Models.ACME;
using DataAccess.ACME;


namespace Services.ACME
{
    public class EmpresaServices
    {
        public bool Crear(EmpresaEntidad empresaEntidad)
        {
            EmpresaDA empresaDA = new EmpresaDA();

            try
            {
                empresaDA.Insertar(empresaEntidad);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Actualizar(EmpresaEntidad empresaEntidad)
        {
            EmpresaDA empresaDA = new EmpresaDA();

            try
            {
                empresaDA.Modificar(empresaEntidad);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public EmpresaEntidad? BuscarxID(int IDEmpresa)
        {
            EmpresaDA? empresaDA = new EmpresaDA();

            try
            {
                return empresaDA.BuscarID(IDEmpresa);
            }
            catch
            {
                return null;
            }
        }
        public List<EmpresaEntidad>? Listar()
        {
            EmpresaDA? empresaDA = new EmpresaDA();

            try
            {
                return empresaDA.Listar();
            }
            catch
            {
                return null;
            }
        }

        public bool Eliminar(EmpresaEntidad empresaEntidad)
        {
            EmpresaDA empresaDA = new EmpresaDA();

            try
            {
                empresaDA.Anular(empresaEntidad);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}