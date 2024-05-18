using Financas.Data.DTOS;
using Financas.Models;
using Financas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Account.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly SignUpService _signUpService;

        public SignUpModel(SignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public SignUpViewModel? Input { get; set; }

        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("/Index");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _signUpService.SignUpAsync(Input!);


            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
