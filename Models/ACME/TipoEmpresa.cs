namespace Models.ACME
{
    public class TipoEmpresa
    {
        public int IDempresa { get; set; }
        
        public string tipoempres {  get; set; } = string.Empty;

        public string descripcion { get; set;} = string.Empty;

        public string sigla { get; set;} = string.Empty;

        public bool activo { get; set; } = true;
    }
}
