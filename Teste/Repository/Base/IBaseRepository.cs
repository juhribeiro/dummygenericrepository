using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.Data;

namespace Teste.Repository.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

    }
}