using Alura_Challenge_Backend_3.Helpers;
using Alura_Challenge_Backend_3.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models
{
    public class FileUpload : IFileUpload
    {
        private string resultMessage = string.Empty;

        [Required(ErrorMessage = "Nenhum arquivo foi selecionado")]
        public IFormFile? FormFile { get; set; }
        public string ResultMessage { get => resultMessage; }

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
                try
                {
                    var transaction = Transaction.CreateTransactionByCsvLine(line);
                    transactions.Add(transaction);
                }
                catch (Exception e) when (e is ArgumentNullException || e is FormatException)
                {
                    // Add prop to counter the lines that were not converted.
                }
                line = reader.ReadLine();
            }

            return transactions;
        }

        // In the case that the prop ResultMessage get more complex.
        // This ResultMessage prop could be a new class responsible to define output messages. Removing these if's and making more managable to deal with.
        public void SetResultMessage(int savedItems, int originalListLength)
        {
            if (savedItems > 0)
            {
                resultMessage = $"{savedItems} item(s) da lista foram salvos.";
                if (originalListLength > savedItems) resultMessage += $"{originalListLength - savedItems} item(s) não foi(ram) salvo(s).";
            }
            else
            {
                resultMessage = "Nenhum item foi salvo. Verifique a lista enviada.";
            };
        }

        public void SetResultMessage(string message) => resultMessage = message;
    }
}
