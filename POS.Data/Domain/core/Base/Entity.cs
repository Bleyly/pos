using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public abstract class Entity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Nombre")] public string Name { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Descipción")] public string Description { get; set; }
    }
}