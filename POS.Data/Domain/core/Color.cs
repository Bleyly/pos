using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Color : Entity
    {
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Valor Hexadecimal")] public string Hexadecimal { get; set; }
    }
}