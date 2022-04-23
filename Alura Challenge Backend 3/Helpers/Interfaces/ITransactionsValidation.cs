using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Helpers.Interfaces
{
    public interface ITransactionsValidation
    {
        IEnumerable<Transaction> Validate(IEnumerable<Transaction> transactions);
    }
}