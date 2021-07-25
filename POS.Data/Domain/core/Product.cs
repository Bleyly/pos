using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Data
{
    public class Product : Entity
    {
        [Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required(ErrorMessage = "{0} es requerido")] public string ImageURL { get; set; }
        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Tipo")] public int TypeId { get; set; }
        public Type Type { get; set; }

        [Required(ErrorMessage = "{0} es requerido"), Display(Name = "Precio")] public decimal Price { get; set; }

        public IEnumerable<ProductSizeColor> SizesAndColors { get; set; }
    }
}