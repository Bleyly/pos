using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using POS.Data;

namespace POS.Models
{
    public class ProductCreateViewModel : Product
    {
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Imagen")]
        public IFormFile Image { get; set; }
    }
}