using Financas.Data.DTOS;
using Financas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Services
{
    public class SignUpService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SignUpService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }
    }
}
