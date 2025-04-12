using Microsoft.EntityFrameworkCore;
using TareasApp.Models;

namespace TareasApp.Data
{
    public class TareasDbContext: DbContext
    {
        public TareasDbContext(DbContextOptions<TareasDbContext>options) : base(options)
        {
        }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
