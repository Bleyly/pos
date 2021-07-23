using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required, Display(Name = "Nombre")] public string Name { get; set; }
        [Required, Display(Name = "Apellido")] public string LastName { get; set; }
        [Required, Display(Name = "Dirección")] public string Address { get; set; }
        [Required, Display(Name = "Ciudad")] public string City { get; set; }
        [Required] public string Sector { get; set; }
        [Required, Display(Name = "Teléfono")] public string PhoneNumber { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}