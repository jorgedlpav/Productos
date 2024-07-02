
using System.ComponentModel.DataAnnotations;
namespace MiPrimerAppMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre es Requerido!!")]
        [Display(Name ="Nombre")]
        public string? Nombre { get; set; }
        [Required]
        [Display(Name ="Descripción")]
        public string? Descripcion { get; set; }
        [Required]
        [Display(Name ="Precio MXP")]
        public Decimal Precio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaDeAlta { get; set; }        

        
    }
}