using System.ComponentModel.DataAnnotations;

namespace BlogCore.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Ingrese un nombre para la categoria")]
        [Display(Name ="Nombre de la Categoría")]
        public string? Nombre { get; set; }
        [Display(Name = "Orden de Visualización")]
        [Range(1,100, ErrorMessage ="El valor debe ser entre 1 y 100")]
        public int Orden { get; set; }
    }
}
