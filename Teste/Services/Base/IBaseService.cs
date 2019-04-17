using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Services.Base
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task<T> AddAsync(T model);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}