﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCore.Domain.Entities
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre es obligatorio")]
        [Display(Name ="Nombre del Artículo")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La Descripción es obligatorio")]
        public string? Descripcion { get; set; }
        [Display(Name = "Fecha de creación")]
        public string? FechaCreacion { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? UrlImagen { get; set; }
        [Required(ErrorMessage = "La Categoría es obligatorio")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }
}
