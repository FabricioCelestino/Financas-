using Financas.Models;

namespace Financas.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
