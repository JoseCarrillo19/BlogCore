using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCore.Domain.Entities.ViewModels
{
    public class ArticuloVM
    {
        public Articulo? Articulo { get; set; }
        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }
    }
}
