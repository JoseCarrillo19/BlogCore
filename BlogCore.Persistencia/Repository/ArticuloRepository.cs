using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Domain.IRepository;

namespace BlogCore.Persistencia.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Articulo> AsQueryable()
        {
            return _context.Set<Articulo>().AsQueryable();
        }

        public void Update(Articulo articulo)
        {
            var response = _context.Articulos.FirstOrDefault(x => x.Id == articulo.Id);
            response!.Nombre = articulo.Nombre;
            response.Descripcion = articulo.Descripcion;
            response.UrlImagen = articulo.UrlImagen;
            response.CategoriaId = articulo.CategoriaId;   
        }
    }
}
