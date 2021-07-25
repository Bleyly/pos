using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Data
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().Include(product => product.Type).ToListAsync();
        }
    }
}