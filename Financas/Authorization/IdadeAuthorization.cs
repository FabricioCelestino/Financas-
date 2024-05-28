using Financas.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Financas.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var idadeClaim = context.User.FindFirst(c => c.Type == "idade");

            if (idadeClaim is null)
                return Task.CompletedTask;

            var idade = int.Parse(idadeClaim.Value);

            if (idade >= requirement.Idade)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}
