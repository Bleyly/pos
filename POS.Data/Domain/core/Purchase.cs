using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required] public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public IEnumerable<ProductPurchase> Products { get; set; }
        [Required, Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required] public decimal Total { get; set; }
    }
}