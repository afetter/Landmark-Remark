using Domain.Interface;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EF
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseModel
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await context.Set<TEntity>().AsNoTracking().AnyAsync(filter);
        }

        public async Task<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            return await context.Set<TEntity>().AsNoTracking().Where(filter).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            return context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
