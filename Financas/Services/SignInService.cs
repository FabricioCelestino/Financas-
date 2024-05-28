using Financas.Data.DTOS;
using Financas.Exceptions;
using Financas.Interfaces;
using Financas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Financas.Services
{
    public class SignInService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public SignInService(SignInManager<User> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<SignInResult> SignInAsync(SignInDTO input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, input.RememberMe, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    throw new LockoutUSerException("O usuário foi bloquado devido a muitas tentativas de login," +
                        " Por favor tente novamente em 5 minutos");
                }

                throw new UnauthenticatedUserException("Email ou senha do usuário está incorreto");

            }
            
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(user => user.NormalizedEmail == input.Email.ToUpper());

            var token = _tokenService.GenerateToken(user!);

            return result;
        }
    }
}
