using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Context;
using ToDo.Infra.Ropository;

namespace ToDo.Infra.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context)
        {
        }

        public Task<UserEntity> FindByLogin(string email, string password)
        {
            try
            {
                return _dataSet.FirstOrDefaultAsync(user => user.Email.Equals(email) && user.Password.Equals(password));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserEntity> SelectByEmail(string email)
        {
            try
            {
                return await _dataSet.FirstOrDefaultAsync(user => user.Email.Equals(email));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}