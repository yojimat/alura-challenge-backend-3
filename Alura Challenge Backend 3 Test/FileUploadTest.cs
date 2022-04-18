using Alura_Challenge_Backend_3.Models;
using System.Collections.Generic;
using Xunit;

namespace Alura_Challenge_Backend_3_Test
{
    public class FileUploadTest
    {
        [Fact]
        public void Should_Return_A_List_Of_Transactions()
        {
            FileUpload fileUpload = new()
            {
                FormFile = null // Finish the implementation of the initial part of the test
            };

            IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

            Assert.NotNull(list);
            // Think of a way of comparing the two list to see if they are equal
            // Assert.Collection(list,(item) => list.Contains(item));
        }

        [Fact]
        public void Should_Return_Empty_List()
        {
            FileUpload fileUpload = new();

            IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

            Assert.NotNull(list);
            Assert.Empty(list);
        }
    }
}