using Financas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Financas.Data.DataAcess
{
    public class ApplicationDataBase : IdentityDbContext<User>
    {

        public ApplicationDataBase(DbContextOptions<ApplicationDataBase> options) : base(options) 
        {
        
        }

        
    }
}
