using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Data
{
    [Table("ProductPurchaseSizeColor")]
    public class ProductPurchaseSizeColor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int ProductPurchaseId { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int SizeId { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int ColorId { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Cantidad")] public int Quantity { get; set; }
        public ProductPurchase ProductPurchase { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
    }
}