using Domain.Common;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    }
}
