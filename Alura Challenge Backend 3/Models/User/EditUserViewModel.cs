using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Alura_Challenge_Backend_3.Models.User;

public class EditUserViewModel
{
    public string Id { get; set; } = string.Empty;

    [DisplayName("Nome")]
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    public string Name { get; set; } = string.Empty;

    public string Error { get; set; } = string.Empty;
}
