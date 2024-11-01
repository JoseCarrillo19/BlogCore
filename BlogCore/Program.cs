using BlogCore.Data;
using BlogCore.Domain.Entities;
using BlogCore.Domain.IRepository;
using BlogCore.Persistencia.Data.Inicializador;
using BlogCore.Persistencia.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();

builder.Services.AddScoped<IInicializador, Inicializador>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

SiembraDatos();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Usuario}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

void SiembraDatos()
{
    using (var scope = app.Services.CreateScope())
    {
        var inicializadorBD = scope.ServiceProvider.GetRequiredService<IInicializador>();
        inicializadorBD.Inicializar();
    }
}
