namespace Alura_Challenge_Backend_3.Models.Interfaces
{
    public interface IFileUpload
    {
        string ReadFileNameAndLength();
        IEnumerable<Transaction> ReadCSVFile();
        void SetResultMessage(int savedItems, int originalListLength);
        void SetResultMessage(string message);
        void SetListForImportedTransactionTables(IEnumerable<Transaction> listOfTransactions);
    }
}