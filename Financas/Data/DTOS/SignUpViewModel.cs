using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financas.Data.DTOS
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Digite seu nome")]
        [DisplayName("Nome")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Digite seu Sobremone")]
        [DisplayName("Sobrenome")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Digite seu endereço de email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DisplayName("Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? PassowdConfirm { get; set; }

        [Required(ErrorMessage = "Digite o número do seu celular")]
        [DisplayName("Telefone Celular")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
