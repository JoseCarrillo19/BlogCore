using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Domain.IRepository;

namespace BlogCore.Persistencia.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Update(Categoria categoria)
        {
            var response = _context.Categorias.FirstOrDefault(x => x.Id == categoria.Id);
            response!.Nombre = categoria.Nombre;
            response.Orden = categoria.Orden;
            _context.SaveChanges();
        }
    }
}
