using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces.Services;
using Travel.Web.ViewModels;

namespace Travel.Web.Controllers
{
    public class LibroController : Controller
    {
        private readonly IEditorialService _editorialService;
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;
        private readonly IAutoresHasLibroService _autoresHasLibroService;
        public LibroController(ILibroService libroService,
                               IEditorialService editorialService, 
                               IAutorService autorService,
                               IAutoresHasLibroService autoresHasLibroService)
        {
            _libroService = libroService;
            _editorialService = editorialService;
            _autorService = autorService;
            _autoresHasLibroService = autoresHasLibroService;
        }
        public async Task<IActionResult> Index()
        {
            //var libros = await _libroService.ObtenerLibros();
            var libros = await _libroService.ObtenerLibrosConEditoriales();            
            return View(libros);
        }

        // GET: libro/Create
        public async Task<IActionResult> Create()
        {
            var editorariales = await _editorialService.ObtenerEditoriales();
            List<SelectListItem> items = editorariales.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                await _libroService.CreateLibro(libro);
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }
        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var libro = await _libroService.ObtenerLibro(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro)
        {
            if (id != libro.Isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    libro.Isbn = id;

                    await _libroService.ActualizarLibro(libro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        public async Task<IActionResult> Details(int id)
        {
            var autoresRelacionados = await _autoresHasLibroService.ObtenerAutorHasLibroPorLibroAll(id);
            var libro = await _libroService.ObtenerLibroConEditoriales(id);

            var libroResult = new LibroViewModel();
            libroResult.Isbn = libro.Isbn;
            libroResult.Titulo = libro.Titulo;
            libroResult.Sinopsis = libro.Sinopsis;
            libroResult.NPaginas = libro.NPaginas;
            libroResult.EditorialesNavigation = libro.EditorialesNavigation;
            libroResult.AutoresHasLibros = autoresRelacionados;

            ViewBag.AutoresRelacionados = autoresRelacionados;

            if (libro == null)
            {
                return NotFound();
            }


            return View(libroResult);
        }

        public async Task<IActionResult> AddAutor(int id)
        {

            var libro = await _libroService.ObtenerLibroConEditoriales(id);
            ViewBag.Titulo = libro.Titulo;
            ViewBag.Isbn = libro.Isbn;
        

            var autores = await _autorService.ObtenerAutores();
            List<SelectListItem> items = autores.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAutor(AutoresHasLibro autoresHasLibro)
        {
            if (ModelState.IsValid)
            {
                await _autoresHasLibroService.CreateAutorHasLibro(autoresHasLibro); 
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
