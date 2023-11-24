using QSMS.Domain.Abstract;
using QSMS.Domain.Entities.Common;
using System.Linq.Expressions;

namespace QSMS.Application.Repositories.Abstract
{
    public interface IEntityRepository<T> where T : BaseEntity,IEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> RemoveAsync(int id);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
