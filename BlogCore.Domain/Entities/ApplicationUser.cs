using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogCore.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La Direccion es obligatorio")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "La Ciudad es obligatorio")]
        public string? Ciudad { get; set; }

        [Required(ErrorMessage = "El Pais es obligatorio")]
        public string? Pais { get; set; }
    }
}
