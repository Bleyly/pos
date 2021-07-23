using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class ProductPurchase
    {
        public int Id { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int PurchaseId { get; set; }
        public Product Product { get; set; }
        public Purchase Purchase { get; set; }
        [Required, Display(Name = "Precio Unitario")] public decimal UnitPrice { get; set; }
        [Required, Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required, Display(Name = "Precio Total")] public decimal TotalPrice { get; set; }

        public IEnumerable<ProductPurchaseSizeColor> SizesAndColors { get; set; }
    }
}