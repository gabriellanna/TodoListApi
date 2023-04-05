using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Services
{
    public interface ITokenService
    {
         public string GenerateToken(UserEntity user);
    }
}