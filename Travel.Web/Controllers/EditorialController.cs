using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces.Services;

namespace Travel.Web.Controllers
{
    public class EditorialController : Controller
    {
        private readonly IEditorialService _editorialService;
        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }
        public async Task<IActionResult> Index()
        {
            var editoriales = await _editorialService.ObtenerEditoriales();
            return View(editoriales);
        }

        // GET: Editorial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                await _editorialService.CrearEditorial(editorial);
                return RedirectToAction(nameof(Index));
            }
            return View(editorial);
        }
        // GET: Editorial/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var editorial = await _editorialService.ObtenerEditorial(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }

        // POST: Autor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    editorial.Id = id;

                    await _editorialService.ActualizarEditorial(editorial);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(editorial);
        }
    }
}
