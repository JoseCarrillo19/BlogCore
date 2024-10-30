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
        public int Orden { get; set; }
    }
}
