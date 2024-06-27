using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace NominaAPI.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<T> GetById(int id);
        Task DeleteAsync(T entity);
       
        Task DeleteRangeAsync(List<T> entities);

        Task SaveChangesAsync();
        Task<bool> ExistsAsync(Expression<Func<T, bool>>? filter = null);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
