using Financas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Financas.Data.DataAcess
{
    public class ApplicationDataBase : DbContext
    {

        public ApplicationDataBase(DbContextOptions<ApplicationDataBase> options) : base(options) 
        {
        
        }

        public DbSet<User> Users { get; set; }
    }
}
