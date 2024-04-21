using System.ComponentModel.DataAnnotations;
namespace Models.ACME
{
    public class EmpresaEntidad
    { 

        [Range(0, int.MaxValue, ErrorMessage = "Debe de selecionar una empresa")]
        [Display(Name ="Codigo")]
        public int IDempresa { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de empresa.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una empresa.")]
        [Display(Name = "Tipo empresa")]
        public int IDTipoempresa { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        [Display(Name = "Nombre empresa")]
        public string empresa { get; set; } = string.Empty;

        [Required(ErrorMessage = "La direccion de la empresa es obligatorio.")]
        [Display(Name = "Direccion")]
        public string direccion {  get; set; } = string.Empty ;

        [Required(ErrorMessage = "El RUC de la empresa es obligatorio.")]
        [Display(Name = "RUC")]
        public string RUC { get; set; } = string.Empty ;

        [Required(ErrorMessage = "Debe ingresar la fecha de creacion.")]
        [Display(Name = "Fecha creacion")]
        public DateTime fechacreacion { get; set; } = DateTime.Now ;

        [Required(ErrorMessage = "Debe ingresar el presupuesto.")]
        [Display(Name = "Presupuesto")]
        public decimal presupuesto { get; set; }

        public bool activo { get; set; } = true;

        public TipoEmpresa? TipoEmpresa { get; set; }
    }
}
