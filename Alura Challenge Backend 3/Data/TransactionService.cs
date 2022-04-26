using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura_Challenge_Backend_3.Data
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionContext _transactionContext;
        private readonly ILogger _logger;

        public TransactionService(TransactionContext context, ILogger logger)
        {
            _transactionContext = context;
            _logger = logger;
        }

        public int SaveTransactions(IEnumerable<Transaction> transactions)
        {
            using var transaction = _transactionContext.Database.BeginTransaction();
            try
            {
                _transactionContext.Transactions?.AddRange(transactions);
                int savedItems = _transactionContext.SaveChanges();
                if (transactions.Count() != savedItems) throw new InvalidOperationException("Not all items were saved");
                transaction.Commit();
                return savedItems;
            }
            catch (Exception e)
            {
                _logger.LogError("An error ocurred when inserting transactions : {message}", e.Message);
                transaction.Rollback();
                return 0;
            }
        }

        public bool VerifyIfTransactionExistByDate(DateTime dateOfTransaction)
        {
            bool? found = _transactionContext.Transactions?.Any(t => t.DateTime.CompareTo(dateOfTransaction) == 0);
            return found is not null && found.Value;
        }

        IEnumerable<Transaction> ITransactionService.GetTransactions()
        {
            var listOfTransactions = _transactionContext.Transactions?.AsNoTracking().Select(s => s);
            return listOfTransactions is null ? Enumerable.Empty<Transaction>() : listOfTransactions;
        }
    }
}