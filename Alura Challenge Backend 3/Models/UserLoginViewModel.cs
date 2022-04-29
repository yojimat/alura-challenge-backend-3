using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [EmailAddress(ErrorMessage = "Formato do {0} inválido")]
    [DisplayName("E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [DisplayName("Senha")]
    public string Password { get; set; } = string.Empty;

    public string Error { get; private set; } = string.Empty;

    public void SetError(string message) => Error = message;
}

