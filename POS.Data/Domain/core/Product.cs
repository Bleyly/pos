using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Data
{
    public class Product : Entity
    {
        [Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required] public string ImageURL { get; set; }
        [Required] public int TypeId { get; set; }
        public Type Type { get; set; }

        public IEnumerable<ProductSizeColor> SizesAndColors { get; set; }
    }
}