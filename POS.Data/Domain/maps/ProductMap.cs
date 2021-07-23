using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Data
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(Product => Product.Id);

            builder.HasMany(product => product.SizesAndColors)
            .WithOne(sizesAndColors => sizesAndColors.Product)
            .HasForeignKey(sizesAndColors => sizesAndColors.ProductId);
        }
    }
}