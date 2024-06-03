using Financas.Data.DTOS;
using Financas.Exceptions;
using Financas.Interfaces;
using Financas.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Financas.Services
{
    public class SignInService : ISignInService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ProtectedLocalStorage _LocalStorage;

        public SignInService(SignInManager<User> signInManager, ITokenService tokenService, ProtectedLocalStorage localStorage)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _LocalStorage = localStorage;
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

            await _LocalStorage.SetAsync("LocalStore", "BearerToken", token);
            
            
            return result;
        }
    }
}
