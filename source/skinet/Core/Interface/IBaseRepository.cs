using Core.Entities;
using Core.Specifications;

namespace Core.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task<int> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}