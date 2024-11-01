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
            Articulo = new ArticuloRepository(context);
            Slider = new SliderRepository(context);
            Usuario = new UsuarioRepository(context);
        }

        public ICategoriaRepository Categoria {  get; private set; }
        public IArticuloRepository Articulo {  get; private set; }
        public ISliderRepository Slider {  get; private set; }
        public IUsuarioRepository Usuario {  get; private set; }

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
