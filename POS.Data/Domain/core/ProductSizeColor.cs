using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class ProductSizeColor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int ProductId { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int SizeId { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public int ColorId { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Cantidad")] public int Quantity { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
    }
}