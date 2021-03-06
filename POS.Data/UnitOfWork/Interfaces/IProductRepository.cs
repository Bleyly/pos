using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByTypeAsync(int typeId);
    }
}