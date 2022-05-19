using Alura_Challenge_Backend_3.Helpers;
using Alura_Challenge_Backend_3.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Alura_Challenge_Backend_3.Models
{
    public class FileUploadViewModel : IFileUpload
    {
        private int invalidItens = 0;

        [Required(ErrorMessage = "Nenhum arquivo foi selecionado")]
        public IFormFile? FormFile { get; set; }
        public string ResultMessage { get; private set; } = string.Empty;
        public IEnumerable<(DateTime, DateTime)> ListForImportedTransactionsTable { get; private set; } = Enumerable.Empty<(DateTime, DateTime)>();

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
                    invalidItens += 1;
                }
                line = reader.ReadLine();
            }

            return transactions;
        }

        public void SetListForImportedTransactionTables(IEnumerable<Transaction> listOfTransactions) =>
            ListForImportedTransactionsTable =
                listOfTransactions.OrderByDescending(a => a.DateTime).GroupBy(i => i.ImportedDateTime)
                                  .Select(group => (group.First().DateTime, group.Key));

        // In the case that the prop ResultMessage get more complex.
        // This ResultMessage prop could be a new class responsible to define output messages. Removing these if's and making more managable to deal with.
        public void SetResultMessage(int savedItems, int originalListLength)
        {
            if (savedItems > 0)
            {
                ResultMessage = $"{savedItems} item(s) válido(s).";
                if (originalListLength > savedItems) ResultMessage += $" {originalListLength - savedItems + invalidItens} item(s) inválido(s).";
            }
            else
            {
                ResultMessage = "Nenhum item foi salvo. Verifique a lista enviada.";
            };
        }

        public void SetResultMessage(string message) => ResultMessage = message;
    }
}
