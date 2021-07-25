using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Sale
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<ProductSale> Products { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public decimal Total { get; set; }
    }
}