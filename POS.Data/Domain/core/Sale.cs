using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data
{
    public class Sale
    {
        public int Id { get; set; }
        [Required] public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<ProductSale> Products { get; set; }
        [Required, Display(Name = "Cantidad")] public int Quantity { get; set; }
        [Required] public decimal Total { get; set; }
    }
}