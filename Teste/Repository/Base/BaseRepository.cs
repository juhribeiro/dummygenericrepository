using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Data;

namespace Teste.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<T> GetByIdAsync(int id)
        {
            return this._dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> ListAsync()
        {
            return this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await this._dbContext.Set<T>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this._dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
            this._dbContext.Set<T>().Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this._dbContext.Set<T>().Where(expression).ToListAsync();
        }
    }
}