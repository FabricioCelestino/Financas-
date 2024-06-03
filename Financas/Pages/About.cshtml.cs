using Financas.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages
{

    [Authorize(Policy = "IdadeMinima")]
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
          
        }
    }
}
