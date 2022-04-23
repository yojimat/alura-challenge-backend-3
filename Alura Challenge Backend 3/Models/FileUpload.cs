using Alura_Challenge_Backend_3.Helpers;
using Alura_Challenge_Backend_3.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models
{
    public class FileUpload : IFileUpload
    {
        [Required(ErrorMessage = "Nenhum arquivo foi selecionado")]
        public IFormFile? FormFile { get; set; }

        public string ReadFileNameAndLength()
        {
            string? fileName = FormFile?.FileName;
            long? fileLength = FormFile?.Length;

            string result = $"The name of the file is {fileName} and its length is: {FileSizeFormatter.FormatSize(fileLength ?? 0)}";

            Console.WriteLine(result);
            return result;
        }

        public IEnumerable<Transaction> ReadCSVFile()
        {
            if (FormFile == null || FormFile.ContentType != "text/csv") return Enumerable.Empty<Transaction>();
            var transactions = new List<Transaction>();

            using var stream = FormFile.OpenReadStream();
            using var reader = new StreamReader(stream);

            string? line = reader.ReadLine();

            while (line != null)
            {
                transactions.Add(Transaction.CreateTransactionByCsvLine(line));
                line = reader.ReadLine();
            }

            return transactions;
        }


    }
}
