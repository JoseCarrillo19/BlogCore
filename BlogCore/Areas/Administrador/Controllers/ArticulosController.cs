using BlogCore.Domain.Entities.ViewModels;
using BlogCore.Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Administrador.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Administrador")]
    public class ArticulosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM articuloVM = new ArticuloVM()
            {
                Articulo = new Domain.Entities.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            return View(articuloVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloVM articuloVM)
        {
            if(ModelState.IsValid)
            {
                string rutaPrincipal = _webHostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;
                if(articuloVM.Articulo!.Id == 0  && archivo.Count() > 0) 
                { 
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivo[0].FileName);
                    using (var fileStreams = new FileStream(Path.Combine(subida, nombreArchivo + extension), FileMode.Create))
                    {
                        archivo[0].CopyTo(fileStreams);
                    }
                    articuloVM.Articulo.UrlImagen = @"\imagenes\articulos\" + nombreArchivo + extension;
                    articuloVM.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Articulo.Add(articuloVM.Articulo);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
            }
            articuloVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(articuloVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticuloVM articuloVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _webHostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;

                var articuloDesdeBd = _contenedorTrabajo.Articulo.Get(articuloVM.Articulo!.Id);

                if (archivo.Count() > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivo[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivo[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeBd.UrlImagen!.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }


                    using (var fileStreams = new FileStream(Path.Combine(subida, nombreArchivo + extension), FileMode.Create))
                    {
                        archivo[0].CopyTo(fileStreams);
                    }
                    articuloVM.Articulo.UrlImagen = @"\imagenes\articulos\" + nombreArchivo + extension;
                    articuloVM.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Articulo.Update(articuloVM.Articulo);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    articuloVM.Articulo.UrlImagen = articuloDesdeBd.UrlImagen;
                }

                _contenedorTrabajo.Articulo.Update(articuloVM.Articulo);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            articuloVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(articuloVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArticuloVM articuloVM = new ArticuloVM()
            {
                Articulo = new Domain.Entities.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };
            if(id != null)
            {
                articuloVM.Articulo = _contenedorTrabajo.Articulo.Get(id.GetValueOrDefault());  
            }

            return View(articuloVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _contenedorTrabajo.Articulo.Get(id);
            string rutaDirectorioPrincipal = _webHostEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, response.UrlImagen!.TrimStart('\\'));


            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (response == null)
            {
                return Json(new { success = false, message = "Error al eliminar el Artículo" });
            }
            _contenedorTrabajo.Articulo.Remove(response);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Artículo Borrada Correctamente" });
        }

    }
}
