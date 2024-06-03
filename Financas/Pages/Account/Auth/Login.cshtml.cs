using Financas.Data.DTOS;
using Financas.Exceptions;
using Financas.Interfaces;
using Financas.Models;
using Financas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financas.Pages.Auth
{
    public class LoginModel : PageModel
    {

        private readonly ISignInService _signInService;
        private string _message = default!;

        public LoginModel(ISignInService signInService)
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
            returnUrl ??= Url.Content("/Index");

            //Verifica se os campos do formulário não foram preenchidos corretamente
            //Se for o caso, retorna para a página novamente
            if (!ModelState.IsValid)
            {
                return Page();

            }


            try
            {
                //Chama o método responsável por efetuar o login
                var result = await _signInService.SignInAsync(Input!);

                //Caso o login seja bem sucedido,
                //Retorna para a página protegida que chamou a página login ou para a página Index
                return LocalRedirect(returnUrl);
            }
            catch (UnauthenticatedUserException ex)
            {
                _message = ex.Message;

            }
            catch (LockoutUSerException ex)
            {
                _message = ex.Message;

            }

            ModelState.AddModelError(string.Empty, _message);

            return Page();

        }
    }
}
