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

        // GET: INDEX obtiene las tareas de la DB y las pasa a View
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
        //GET para EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Tareas == null)
            {
                return NotFound();
            }
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }


        //POST: para editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarea, Titulo, Descripcion")]Tarea tarea)
        {

            if( id != tarea.IdTarea) 
            {
                return BadRequest();
            }
            if (ModelState.IsValid) 
            {
                try 
                {
                    _context.Update(tarea);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); 
                } 
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaExists(tarea.IdTarea))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(tarea);
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.IdTarea == id);
        }


        //GET: TAREAS Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null || _context.Tareas == null)
            {
                return NotFound();
            }
            var tarea = await _context.Tareas.FindAsync(id);
            if(tarea == null)
            {
                return NotFound();  
            }
            return View(tarea);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Tareas == null)
            {
                return Problem("Entidad a borrar es null");
            }
            var tarea = await _context.Tareas.FindAsync(id);
            if(tarea != null)
            {
                _context.Tareas.Remove(tarea); 
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
