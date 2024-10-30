using BlogCore.Application.Intefaces;
using BlogCore.Domain.IRepository;

namespace BlogCore.Application.Services
{
    public class CategoriasServices : ICategoriasServices
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasServices(IContenedorTrabajo contenedorTrabajo)
        {
             _contenedorTrabajo = contenedorTrabajo;
        }

        
    }
}
