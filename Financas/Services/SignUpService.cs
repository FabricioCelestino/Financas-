using Financas.Data.DTOS;
using Financas.Interfaces;
using Financas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly UserManager<User> _userManager;
        

        public SignUpService(UserManager<User> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDTO input)
        {

            var user = new User
            {
                UserName = input.Email,
                FirstName = input.FirstName!,
                LastName = input.LastName!,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,

            };

            var result = await _userManager.CreateAsync(user, input.Password!);

            return result;
        }
    }
}
