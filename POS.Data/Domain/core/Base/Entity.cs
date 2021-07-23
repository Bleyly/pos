using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public abstract class Entity
    {
        public int Id { get; set; }
        [Required, Display(Name = "Nombre")] public string Name { get; set; }
        [Required, Display(Name = "Descipción")] public string Description { get; set; }
    }
}