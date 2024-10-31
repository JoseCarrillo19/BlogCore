using BlogCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCore.Domain.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);

        IEnumerable<SelectListItem> GetListaCategorias();
    }
}
