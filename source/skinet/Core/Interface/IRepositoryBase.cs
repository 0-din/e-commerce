using Core.Entities;

namespace Core.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task<int> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}