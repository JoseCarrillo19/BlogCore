using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Domain.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCore.Persistencia.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _context.Categorias.Select(x => new SelectListItem()
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
            var response = _context.Categorias.FirstOrDefault(x => x.Id == categoria.Id);
            response!.Nombre = categoria.Nombre;
            response.Orden = categoria.Orden;
        }
    }
}
