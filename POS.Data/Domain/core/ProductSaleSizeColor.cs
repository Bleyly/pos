using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Data
{
    [Table("ProductSaleSizeColor")]
    public class ProductSaleSizeColor
    {
        public int Id { get; set; }
        [Required] public int ProductSaleId { get; set; }
        [Required] public int SizeId { get; set; }
        [Required] public int ColorId { get; set; }
        [Required, Display(Name = "Cantidad")] public int Quantity { get; set; }
        public ProductSale ProductSale { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
    }
}