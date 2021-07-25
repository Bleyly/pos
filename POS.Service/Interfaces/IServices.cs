using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.Service
{
    public interface IService<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}