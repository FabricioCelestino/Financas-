using Financas.Data.DTOS;
using Financas.Exceptions;
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
        private string _message = default!;

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
            returnUrl ??= Url.Content("/Index");

            //Verifica se os campos do formul�rio n�o foram preenchidos corretamente
            //Se for o caso, retorna para a p�gina novamente
            if (!ModelState.IsValid)
            {
                return Page();

            }


            try
            {
                //Chama o m�todo respons�vel por efetuar o login
                var token = await _signInService.SignInAsync(Input!);

                //Caso o login seja bem sucedido,
                //Retorna para a p�gina protegida que chamou a p�gina login ou para a p�gina Index
                return Page();
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
