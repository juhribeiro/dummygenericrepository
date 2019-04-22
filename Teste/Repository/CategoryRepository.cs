using Teste.Data;
using Teste.Repository.Base;

namespace Teste.Repository
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}