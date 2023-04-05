using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
         public Task<UserEntity> SelectByEmail(string email);
         public Task<UserEntity> FindByLogin(string email, string password);
    }
}