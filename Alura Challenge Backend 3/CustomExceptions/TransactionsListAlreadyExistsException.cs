namespace Alura_Challenge_Backend_3.CustomExceptions
{
    public class TransactionsListAlreadyExistsException : Exception
    {
        public TransactionsListAlreadyExistsException()
        {
        }

        public TransactionsListAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
