using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Data;

namespace POS.Service
{
    public interface IProductService : IService<Product>
    {
        Task<IEnumerable<Product>> GetByTypeAsync(int typeId);
    }
}