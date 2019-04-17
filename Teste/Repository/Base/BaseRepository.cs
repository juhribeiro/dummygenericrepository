using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Data;

namespace Teste.Repository.Base
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return this._dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await this._dbContext.Set<T>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync<T>(int id) where T : BaseEntity
        {
            var entity = await this._dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
            this._dbContext.Set<T>().Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }
    }
}