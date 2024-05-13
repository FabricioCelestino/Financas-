using Financas.Models;
using Financas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Account.Auth
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public SignUpViewModel Input { get; set; }
        public void OnGet()
        {
        }
    }
}
