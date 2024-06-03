using Financas.Data.DTOS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Interfaces
{
    public interface ISignUpService
    {
        public Task<IdentityResult> SignUpAsync(SignUpDTO input);
    }
}
