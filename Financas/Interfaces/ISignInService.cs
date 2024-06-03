using Financas.Data.DTOS;
using Microsoft.AspNetCore.Identity;

namespace Financas.Interfaces
{
    public interface ISignInService
    {

        public Task<SignInResult> SignInAsync(SignInDTO input);
    }
}
