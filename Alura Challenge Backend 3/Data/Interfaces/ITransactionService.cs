using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Data.Interfaces
{
    public interface ITransactionService
    {
        public bool SaveTransactions(IEnumerable<Transaction> transactions);
    }
}