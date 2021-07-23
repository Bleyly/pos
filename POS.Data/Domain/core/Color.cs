using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Color : Entity
    {
        [Required, Display(Name = "Valor Hexadecimal")] public string Hexadecimal { get; set; }
    }
}