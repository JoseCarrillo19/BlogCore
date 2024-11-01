using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Persistencia.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogCore.Persistencia.Data.Inicializador
{
    public class Inicializador : IInicializador
    {
        private readonly ApplicationDbContext _bd;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //Creamos el constructor
        public Inicializador(ApplicationDbContext bd, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _bd = bd;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Inicializar()
        {
            try
            {
                if (_bd.Database.GetPendingMigrations().Count() > 0)
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (_bd.Roles.Any(ro => ro.Name == CNT.Administrador)) return;

            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Usuario)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "josecarloscarrillovillazon@gmail.com",
                Email = "josecarloscarrillovillazon@gmail.com",
                EmailConfirmed = true,
                Nombre = "JOSE CARLOS CARRILLO VILLAZON"
            }, "Carrillo19!").GetAwaiter().GetResult();

            ApplicationUser usuario = _bd.ApplicationUsers.
                Where(us => us.Email == "josecarloscarrillovillazon@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, CNT.Administrador).GetAwaiter().GetResult();

        }
    }
}
