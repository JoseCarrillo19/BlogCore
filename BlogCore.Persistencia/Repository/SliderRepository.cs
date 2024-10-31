using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Domain.IRepository;

namespace BlogCore.Persistencia.Repository
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _context;

        public SliderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Slider slider)
        {
            var response = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            response!.Nombre = slider.Nombre;
            response.Estado = slider.Estado;
            response.UrlImagen = slider.UrlImagen;
        }
    }
}
