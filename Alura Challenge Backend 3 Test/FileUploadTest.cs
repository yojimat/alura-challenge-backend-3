using Alura_Challenge_Backend_3.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Alura_Challenge_Backend_3_Test.ModelStubs;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Moq;

namespace Alura_Challenge_Backend_3_Test
{
    public class FileUploadTest
    {
        [Fact]
        public void Should_Return_A_List_Of_Transactions()
        {
            string? path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            string fileName = "transacoes-2022-01-01.csv";
            FileUpload fileUpload = new();

            using Stream fileStream = new MemoryStream(File.ReadAllBytes(@$"{path}\StubFiles\{fileName}"));
            FormFile formFile = new(fileStream, 0, fileStream.Length, "FormFile", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };

            fileUpload.FormFile = formFile;

            IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

            Assert.NotNull(list);
            // Verify if is necessary to implement the an EqualityComparer in the Transaction object.
            Assert.True(list.SequenceEqual(TransactionStubs.TransactionsListStub));
        }

        [Fact]
        public void Should_Return_Empty_List_When_No_File_Is_Send()
        {
            FileUpload fileUpload = new();

            IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public void Should_Ignore_Wrong_Files_Format()
        {
            FileUpload fileUpload = new();
            FormFile formFile = new(Stream.Null, 0, 0, "FormFile", "Wrong Format File")
            {
                Headers = new HeaderDictionary(),
                ContentType = "some wrong format"
            };

            fileUpload.FormFile = formFile;

            IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

            Assert.NotNull(list);
            Assert.Empty(list);
        }
    }
}