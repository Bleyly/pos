using System.Threading.Tasks;

namespace POS.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        Task GetAllWithType();
    }
}