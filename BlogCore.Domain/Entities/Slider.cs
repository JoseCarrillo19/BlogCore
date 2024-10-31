using System.ComponentModel.DataAnnotations;

namespace BlogCore.Domain.Entities
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del Slider")]
        [Display(Name = "Nombre Slider")]
        public string? Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? UrlImagen { get; set; }
    }
}
