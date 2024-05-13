using Financas.Models;
using Financas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Auth
{
    public class LoginModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public SignInViewModel Input { get; set; }

        public void OnGet()
        {
        }


    }
}
