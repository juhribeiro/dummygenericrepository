using AutoMapper;
using Teste.Data;
using Teste.Models;
using Teste.Repository.Base;

namespace Teste.Repository
{
    public class CategoryRepository : BaseRepository<CategoryEntity, Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}