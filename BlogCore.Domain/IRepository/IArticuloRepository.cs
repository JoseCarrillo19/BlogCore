using BlogCore.Domain.Entities;

namespace BlogCore.Domain.IRepository
{
    public interface IArticuloRepository : IRepository<Articulo>
    {
        void Update(Articulo articulo);
    }
}
