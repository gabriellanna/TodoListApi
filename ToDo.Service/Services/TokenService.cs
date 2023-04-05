using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Services;
using ToDo.Service.Configurations;

namespace ToDo.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _configuration;

        public TokenService(TokenConfiguration tokenConfigurations)
        {
            _configuration = tokenConfigurations;
        }
        public string GenerateToken(UserEntity user)
        {
             var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Aud, _configuration.Audience),
                    new Claim(JwtRegisteredClaimNames.Iss, _configuration.Issuer)
                }),
                Expires = DateTime.Now.AddDays(_configuration.TimeToExpiry),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}