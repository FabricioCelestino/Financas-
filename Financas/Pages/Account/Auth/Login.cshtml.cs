using Financas.Data.DTOS;
using Financas.Models;
using Financas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Auth
{
    public class LoginModel : PageModel
    {

        private readonly SignInService _signInService;

        public LoginModel(SignInService signInService)
        {
            _signInService = signInService;
        }

        public void OnGet()
        {
        }

        [BindProperty(SupportsGet = true)]
        public SignInDTO Input { get; set; } = default!;

        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("/Index");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _signInService.SignInAsync(Input!);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            if(result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Usuário bloqueado, Tente novamente " +
                    "em 5 minutos");
            }

            return Page();

        }
    }
}
