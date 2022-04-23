using Alura_Challenge_Backend_3.CustomExceptions;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Helpers.Interfaces;
using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Helpers
{
    public class TransactionsValidation : ITransactionsValidation
    {
        private readonly ITransactionService _transactionService;

        public TransactionsValidation(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IEnumerable<Transaction> Validate(IEnumerable<Transaction> transactions)
        {
            DateTime dateOfTransaction = GetDateOfFirstValidTransaction(transactions);

            if (VerifyIfDateOfTransactionsAlreadyExists(dateOfTransaction))
            {
                throw new TransactionsListAlreadyExistsException();
            };

            var filteredTransactionByDate = FilterTransactionsByDate(transactions, dateOfTransaction);
            var validatedTransactions = ValidateAllTransactionsProps(filteredTransactionByDate);

            return validatedTransactions;
        }

        private static IEnumerable<Transaction> ValidateAllTransactionsProps(IEnumerable<Transaction> filteredTransactionByDate) =>
            filteredTransactionByDate.Where(transaction =>
            !string.IsNullOrWhiteSpace(transaction.OriginBank) &&
            transaction.OriginAgency > 0 &&
            !string.IsNullOrWhiteSpace(transaction.OriginAccount) &&
            !string.IsNullOrWhiteSpace(transaction.DestinationBank) &&
            transaction.DestinationAgency > 0 &&
            !string.IsNullOrWhiteSpace(transaction.DestinationAccount) &&
            transaction.Value > 0);

        private static IEnumerable<Transaction> FilterTransactionsByDate(IEnumerable<Transaction> transactions, DateTime dateOfTransaction)
        {
            return transactions.Where(transaction => transaction.DateTime.Date.CompareTo(dateOfTransaction.Date) == 0);
        }

        private bool VerifyIfDateOfTransactionsAlreadyExists(DateTime dateOfTransaction)
        {
            return _transactionService.VerifyIfTransactionExistByDate(dateOfTransaction);
        }

        private static DateTime GetDateOfFirstValidTransaction(IEnumerable<Transaction> transactions)
        {
            var transactionFound = transactions.First();
            return transactionFound.DateTime;
        }
    }
}
