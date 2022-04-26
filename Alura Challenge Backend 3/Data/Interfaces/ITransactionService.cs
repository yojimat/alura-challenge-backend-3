using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Data.Interfaces
{
    public interface ITransactionService
    {
        int SaveTransactions(IEnumerable<Transaction> transactions);
        bool VerifyIfTransactionExistByDate(DateTime dateOfTransaction);
        IEnumerable<Transaction> GetTransactions();
    }
}