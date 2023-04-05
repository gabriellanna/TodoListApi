using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ToDo.Domain.Dtos.User;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.ViewModels;

namespace ToDo.Service.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService (IUserRepository repository, ITokenService tokenService, IMapper mapper)
        {
            _repository = repository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            var user = await _repository.SelectAsync(id);
            if(user == null)
                throw new Exception("Usuario não encontrado");
            return await _repository.DeleteAsync(id);
        }

        public async Task<TokenViewModel> FindByLogin(UserLoginDto user)
        {
            var userDb = await _repository.FindByLogin(user.Email, EncryptPassword(user.Password));
            if(userDb == null) throw new Exception("Usario ou senha incorretos");

            return new TokenViewModel(true, DateTime.Now.ToString(), DateTime.Now.AddDays(7).ToString(), _tokenService.GenerateToken(userDb), userDb);
        }

        public async Task<UserEntity> Get(int id)
        {
            var user = await _repository.SelectAsync(id);
            return user;
        }

        public async Task<IList<UserEntity>> GetAll()
        {
            var users = await _repository.SelectAsync();
            return users;
        }

        public async Task<UserEntity> Post(UserInsertDto user)
        {
            var userConsulta = await _repository.SelectByEmail(user.Email);
            if(userConsulta != null)
                throw new Exception("Email já cadastrado!");
            var userMap = _mapper.Map<UserEntity>(user);
            userMap.CreateAt = DateTime.Now;
            userMap.Password = EncryptPassword(userMap.Password);
            var userDb = await _repository.InsertAsync(userMap);
            return userDb;
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            var userDb = await _repository.SelectAsync(user.Id);
            if(!string.IsNullOrEmpty(user.Email))
                userDb.Email = user.Email;
            if(!string.IsNullOrEmpty(user.Password))
                userDb.Password = EncryptPassword(user.Password);
            if(!string.IsNullOrEmpty(user.Name))
                userDb.Name = user.Name;
            userDb.UpdateAt = DateTime.Now;
            return await _repository.UpdateAsync(userDb);
        }

        private static string EncryptPassword(string password)
        {

            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var caracter in hashedBytes)
            {
                sb.Append(caracter.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}