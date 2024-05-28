using Microsoft.AspNetCore.Authorization;

namespace Financas.Authorization
{
    public class IdadeMinima(int idade) : IAuthorizationRequirement
    {
        public int Idade { get; set; } = idade;
    }
}
