namespace Alura_Challenge_Backend_3.Models.Interfaces
{
    public interface IFileUpload
    {
        string ReadFileNameAndLength();
        IEnumerable<Transaction> ReadCSVFile();
    }
}