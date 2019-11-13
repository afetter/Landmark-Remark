using Domain.Model;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRepository<TEntity>
        where TEntity : BaseModel
    {
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        IQueryable<TEntity> GetAllAsync();

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}
