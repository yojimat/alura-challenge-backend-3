using Alura_Challenge_Backend_3.Models;

namespace Alura_Challenge_Backend_3.Interfaces
{
    public interface IFileUpload
    {
        string ReadFileNameAndLength();
        IEnumerable<Transaction> ReadCSVFile();
    }
}