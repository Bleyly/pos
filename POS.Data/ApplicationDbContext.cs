using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace POS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ColorMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new PurchaseMap());
            builder.ApplyConfiguration(new SaleMap());
            builder.ApplyConfiguration(new SizeMap());
            builder.ApplyConfiguration(new SupplierMap());
        }
    }
}
