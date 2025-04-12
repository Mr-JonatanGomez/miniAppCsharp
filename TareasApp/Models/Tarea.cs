using System.ComponentModel.DataAnnotations;

namespace TareasApp.Models
{
    public class Tarea
    {
        [Key]
        public int IdTarea {  get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
    }
}
