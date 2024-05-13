using Financas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Account.Auth
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User? InputUser { get; set; }
        public void OnGet()
        {
        }
    }
}
