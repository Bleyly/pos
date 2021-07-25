using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Data;

namespace POS.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetByTypeAsync(int typeId)
        {
            return await _unitOfWork.Products.GetByTypeAsync(typeId);
        }
    }
}