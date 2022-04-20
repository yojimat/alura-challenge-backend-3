using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Data
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionContext _transactionContext;

        public TransactionService(TransactionContext context)
        {
            _transactionContext = context;
        }

        // Implement logger and a bool function to show that was sucessfull with try catch
        public void SaveTransactions(IEnumerable<Transaction> transactions)
        {
            _transactionContext.Transactions.AddRange(transactions);
            _transactionContext.SaveChanges();
        }
    }
}