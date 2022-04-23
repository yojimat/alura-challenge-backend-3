using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;

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

        // Implement logger and a bool function to show that was sucessfull with try catch
        public bool SaveTransactions(IEnumerable<Transaction> transactions)
        {
            try
            {
                _transactionContext.Transactions?.AddRange(transactions);
                int savedItens = _transactionContext.SaveChanges();
                if (transactions.Count() == savedItens) throw new InvalidOperationException("Not all itens were saved");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"An error inserting transactions ocurred: {e.Message}");
                return false;
            }

        }
    }
}