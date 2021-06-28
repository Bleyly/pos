using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.Data
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        Task DeleteAsync(int id);
    }
}