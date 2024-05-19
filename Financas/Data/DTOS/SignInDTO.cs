using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financas.Data.DTOS
{
    public class SignInDTO
    {
        [Required(ErrorMessage = "Digite o seu E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite sua senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }


    }
}
