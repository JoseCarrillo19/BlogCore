using BlogCore.Domain.Entities;
using BlogCore.Domain.Entities.ViewModels;
using BlogCore.Domain.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogCore.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class HomeController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 9)
        {

            var articulos = _contenedorTrabajo.Articulo.AsQueryable();

            // Paginar los resultados
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);

            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
                Articulo = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(articulos.Count() / (double)pageSize)
            };

            ViewBag.IsHome = true;

            return View(homeVM);
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var articuloDesdeBd = _contenedorTrabajo.Articulo.Get(id);
            return View(articuloDesdeBd);
        }

        [HttpGet]
        public IActionResult ResultadoBusqueda(string searchString, int page = 1, int pageSize = 3)
        {
            var articulos = _contenedorTrabajo.Articulo.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                articulos = articulos.Where(e => e.Nombre.Contains(searchString));
            }

            // Paginar los resultados
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);

            // Crear el modelo para la vista
            var model = new ListaPaginada<Articulo>(paginatedEntries.ToList(), articulos.Count(), page, pageSize, searchString);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
