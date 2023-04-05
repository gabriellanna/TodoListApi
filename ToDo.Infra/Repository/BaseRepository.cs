using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Context;

namespace ToDo.Infra.Ropository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ToDoContext _context;
        protected DbSet<T> _dataSet;
        public BaseRepository(ToDoContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await _dataSet.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
                _dataSet.Remove(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<T> SelectAsync(int id)
        {
            T item;
            try
            {
                item = await _dataSet.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public async Task<IList<T>> SelectAsync()
        {
            List<T> list;
            try
            {
                list = await _dataSet.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(entity => entity.Id.Equals(item.Id));

                _context.Entry(result).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return item;
        }
    }
}