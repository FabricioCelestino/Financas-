using Financas.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Financas.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace Financas.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["Secret:key"]!);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("id", user.Id),
                    new(ClaimTypes.Email, user.Email!),
                    new(ClaimTypes.MobilePhone, user.PhoneNumber!),
                    new("idade", user.Idade.ToString())

                }),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(5)
            };

            SecurityToken token = securityTokenHandler.CreateToken(TokenDescriptor);
            return securityTokenHandler.WriteToken(token);
        }

    }
}
