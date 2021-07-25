using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public IEnumerable<ProductPurchase> Products { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public decimal Total { get; set; }
    }
}