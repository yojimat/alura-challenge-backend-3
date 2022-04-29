using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models;

public class UserRegisterViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [DisplayName("Nome")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [EmailAddress(ErrorMessage = "Formato do {0} inválido")]
    [DisplayName("E-mail")]
    public string Email { get; set; } = string.Empty;

    public ICollection<string> Errors { get; } = new List<string>();

    public void SetErrors(IEnumerable<IdentityError> identityErrors)
    {
        foreach (var error in identityErrors)
            Errors.Add(error.Description);
    }
}

