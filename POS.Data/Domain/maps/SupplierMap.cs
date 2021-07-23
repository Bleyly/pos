using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Data
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(Supplier => Supplier.Id);

            builder.HasMany(Supplier => Supplier.Purchases)
                .WithOne(purchase => purchase.Supplier)
                .HasForeignKey(purchase => purchase.SupplierId);
        }
    }
}