using BlogCore.Data;
using BlogCore.Domain.IRepository;

namespace BlogCore.Persistencia.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _context;

        public ContenedorTrabajo(ApplicationDbContext context)
        {
            _context = context;
            Categoria = new CategoriaRepository(context);
        }

        public ICategoriaRepository Categoria {  get; private set; }

        public void Dispose()
        {
           _context.Dispose();
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
