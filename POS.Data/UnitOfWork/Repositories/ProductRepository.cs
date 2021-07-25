using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().Include(product => product.Type).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByTypeAsync(int typeId)
        {
            return await _context.Set<Product>().Where(product => product.TypeId.Equals(typeId)).ToListAsync();
        }
    }
}