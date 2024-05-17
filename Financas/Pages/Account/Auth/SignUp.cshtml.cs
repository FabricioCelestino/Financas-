using Financas.Models;
using Financas.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Account.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;

        public SignUpModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signManager = signInManager;

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

            var user = new User
            {
                UserName = Input.FirstName,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                Password = Input.Password,
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _signManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
           
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
