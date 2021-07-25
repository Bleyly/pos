using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using POS.Data;

namespace POS.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Imagen")]
        public IFormFile Image { get; set; }
    }
}