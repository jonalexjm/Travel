using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces.Services;

namespace Travel.Web.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;
        
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }
        public async Task<IActionResult> Index()
        {
            var autores = await _autorService.ObtenerAutores();
            return View(autores);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                await _autorService.CreateAutor(autor);               
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }
        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            
            var user = await _autorService.ObtenerAutor(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Autor/Edit/5
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    autor.Id = id;

                    await _autorService.ActualizarAutor(autor);
                }
                catch (DbUpdateConcurrencyException)
                {                    
                      return NotFound();              
            
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.ObtenerAutor(id);
            
            if (autor == null)
            {
                return NotFound();
            }

            try
            {
                var response = await _autorService.DeleteProperty(autor);
                //_flashMessage.Confirmation("The category was deleted.");
            }
            catch
            {
                //_flashMessage.Danger("The category can't be deleted because it has related records.");
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
