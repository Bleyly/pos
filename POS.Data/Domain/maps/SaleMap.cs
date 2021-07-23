using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Data
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(Sale => Sale.Id);

            builder.HasMany(Sale => Sale.Products)
                .WithOne(productSale => productSale.Sale)
                .HasForeignKey(productSale => productSale.SaleId);
        }
    }
}