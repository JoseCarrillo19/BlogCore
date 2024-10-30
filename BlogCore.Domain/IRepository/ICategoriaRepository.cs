using BlogCore.Domain.Entities;

namespace BlogCore.Domain.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);
    }
}
