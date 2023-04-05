using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<T> SelectAsync(int id);
        Task<IList<T>> SelectAsync();
    }
}