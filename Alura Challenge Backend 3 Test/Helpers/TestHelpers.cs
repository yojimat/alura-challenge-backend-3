using Microsoft.AspNetCore.Http;
using System.IO;

namespace Alura_Challenge_Backend_3_Test.Helpers
{
    internal static class TestHelpers
    {
        public static FormFile GetFormFileFromStub(string fileName)
        {
            string? path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;

            Stream fileStream = new MemoryStream(File.ReadAllBytes(@$"{path}\StubFiles\{fileName}"));
            FormFile formFile = new(fileStream, 0, fileStream.Length, "FormFile", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };

            return formFile;
        }
    }
}
