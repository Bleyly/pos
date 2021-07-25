using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Data;

namespace POS.Service
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }
    }
}