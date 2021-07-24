using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace POS.Data
{
    public class User : IdentityUser<int>
    {
        [Required, Display(Name = "Nombre")] public string Name { get; set; }
        [Required, Display(Name = "Apellido")] public string LastName { get; set; }
        [Required, Display(Name = "Dirección")] public string Address { get; set; }
        [Required, Display(Name = "Ciudad")] public string City { get; set; }
        [Display(Name = "Teléfono")] public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    }
}