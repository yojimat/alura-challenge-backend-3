using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models.User;

public class RegisterUserViewModel
{
    [DisplayName("E-mail")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [EmailAddress(ErrorMessage = "Formato do {0} inválido")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Nome")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    public string Name { get; set; } = string.Empty;

    public string Error { get; set; } = string.Empty;
}

