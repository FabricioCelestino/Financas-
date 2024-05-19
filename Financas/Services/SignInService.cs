using Financas.Data.DTOS;
using Financas.Models;
using Microsoft.AspNetCore.Identity;

namespace Financas.Services
{
    public class SignInService
    {
        private readonly SignInManager<User> _signInManager;

        public SignInService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignInAsync(SignInDTO input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.Email!, input.Password!, input.RememberMe, true);

            return result;

        }
    }
}
