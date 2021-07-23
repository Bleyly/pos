using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class ProductSale
    {
        public int Id { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int SaleId { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
        [Required, Display(Name = "Precio Unitario")] public decimal UnitPrice { get; set; }
        [Required, Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required, Display(Name = "Precio Total")] public decimal TotalPrice { get; set; }

        public IEnumerable<ProductSaleSizeColor> SizesAndColors { get; set; }
    }
}