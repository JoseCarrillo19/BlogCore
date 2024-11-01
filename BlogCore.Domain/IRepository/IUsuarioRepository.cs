using BlogCore.Domain.Entities;

namespace BlogCore.Domain.IRepository
{
    public interface IUsuarioRepository : IRepository<ApplicationUser>
    {
        void BloquearUsario(string IdUsuario);
        void DesbloquearUsario(string IdUsuario);
    }
}
