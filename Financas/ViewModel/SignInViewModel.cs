using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financas.ViewModel
{
    public class SignInViewModel
    {
        [Required(ErrorMessage ="Digite o seu E-mail")]
        [DataType(DataType.EmailAddress)]
        public String? Email { get; set; }

        [Required(ErrorMessage ="Digite sua senha")]
        [DataType (DataType.Password)]
        public string? Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }

        
    }
}
