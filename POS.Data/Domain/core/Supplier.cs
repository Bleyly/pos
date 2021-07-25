using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Nombre")] public string Name { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Apellido")] public string LastName { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Dirección")] public string Address { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Ciudad")] public string City { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), EmailAddress, Display(Name = "Correo Electrónico")] public string Email { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Teléfono")] public string PhoneNumber { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}