using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models
{
    public class FileUpload
    {
        [Required(ErrorMessage = "Nenhum arquivo foi selecionado")]
        public IFormFile? FormFile { get; set; }
    }
}
