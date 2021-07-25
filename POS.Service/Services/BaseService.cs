using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Data;

namespace POS.Service
{
    public class BaseService<T> : IService<T> where T : class
    {
        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(T entity)
        {
            await _unitOfWork.GetRepository<T>().CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.GetRepository<T>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<T>().GetAllAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _unitOfWork.GetRepository<T>().GetAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}