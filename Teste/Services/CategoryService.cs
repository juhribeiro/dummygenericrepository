using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Teste.Contracts;
using Teste.Data;
using Teste.Models;
using Teste.Repository;
using Teste.Repository.Base;
using Teste.Services.Base;

namespace Teste.Services
{
    public class CategoryService : BaseService<CategoryEntity>, ICategoryService
    {
        public CategoryService(IMapper mapper, ICategoryRepository repository) : base(mapper, repository)
        {
        }

        public async Task<Category> AddAsync(Category model)
        {
            var category = _mapper.Map<CategoryEntity>(model);
            var entity = await this._repository.AddAsync(category);
            var categorymodel = _mapper.Map<Category>(entity);
            return categorymodel;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Category>> ListAsync()
        {
            var entities = await this._repository.ListAsync();
            var categories = _mapper.Map<List<Category>>(entities);
            return categories;
        }

        public Task UpdateAsync(int id, Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}