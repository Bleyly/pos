using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Data
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(Purchase => Purchase.Id);

            builder.HasMany(purchase => purchase.Products)
                .WithOne(productPurchase => productPurchase.Purchase)
                .HasForeignKey(productPurchase => productPurchase.PurchaseId);
        }
    }
}