using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasApp.Data;
using TareasApp.Models;
using System.Threading.Tasks;

namespace TareasApp.Controllers
{
    // Aqui es donde metemos las funciones HTTP
    public class TareasController : Controller
    {
        private readonly TareasDbContext _context;
        public TareasController(TareasDbContext context)
        {
            _context = context;
        }

        // GET: (read) obtiene las tareas de la DB y las pasa a View
        public async Task<IActionResult> Index()
        {
            var tareas = await _context.Tareas.ToListAsync();
            return View(tareas);
        }

        // GET: (create) muestra form para crear tarea
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tareas/Create Recibe datos, valida, y guarda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descripcion")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

    }
}
