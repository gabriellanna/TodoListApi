using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IToDoService
    {
        Task<UserEntity> Get (int id);

        Task<IList<UserEntity>> GetAll ();

        Task<UserEntity> Post (UserEntity user);

        Task<UserEntity> Put (UserEntity user);

        Task<bool> Delete (int id);
    }
}