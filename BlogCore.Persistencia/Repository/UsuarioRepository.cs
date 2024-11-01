using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Domain.IRepository;

namespace BlogCore.Persistencia.Repository
{
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void BloquearUsario(string IdUsuario)
        {
           var usuarioDesdeBd = _context.ApplicationUsers.FirstOrDefault(x => x.Id == IdUsuario);
            usuarioDesdeBd!.LockoutEnd = DateTime.Now.AddYears(1000);
            _context.SaveChanges();
        }

        public void DesbloquearUsario(string IdUsuario)
        {
            var usuarioDesdeBd = _context.ApplicationUsers.FirstOrDefault(x => x.Id == IdUsuario);
            usuarioDesdeBd!.LockoutEnd = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
