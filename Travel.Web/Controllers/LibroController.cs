using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces.Services;

namespace Travel.Web.Controllers
{
    public class LibroController : Controller
    {
        private readonly IEditorialService _editorialService;
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService, IEditorialService editorialService)
        {
            _libroService = libroService;
            _editorialService = editorialService;
        }
        public async Task<IActionResult> Index()
        {
            var libros = await _libroService.ObtenerLibros();
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

    }
}
