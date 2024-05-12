using Financas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Usuario
{
    public class LoginModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public new User User { get; set; }

        public void OnGet()
        {
        }


    }
}
