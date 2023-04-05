using ToDo.Domain.Dtos.User;
using ToDo.Domain.Entities;
using ToDo.Domain.ViewModels;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> Get (int id);

        Task<TokenViewModel> FindByLogin (UserLoginDto user);

        Task<IList<UserEntity>> GetAll ();

        Task<UserEntity> Post (UserInsertDto user);

        Task<UserEntity> Put (UserEntity user);

        Task<bool> Delete (int id);
    }
}