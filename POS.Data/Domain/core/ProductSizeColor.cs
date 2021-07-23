using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class ProductSizeColor
    {
        public int Id { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int SizeId { get; set; }
        [Required] public int ColorId { get; set; }
        [Required, Display(Name = "Cantidad")] public int Quantity { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
    }
}