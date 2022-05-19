using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Helpers;
using Alura_Challenge_Backend_3.Models;
using Alura_Challenge_Backend_3_Test.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace Alura_Challenge_Backend_3_Test;

public class TransactionsValidationTest
{
    private const string dateStringFormat = "yyyy-MM-ddTHH:mm:ss";

    [Fact]
    public void Must_Validate_The_Example_File_Correctly()
    {
        var date = DateTime.ParseExact("2022-01-01T07:30:00", dateStringFormat, CultureInfo.InvariantCulture);
        Mock<ITransactionService> mockTransactionService = new();
        mockTransactionService.Setup(x => x.VerifyIfTransactionExistByDate(It.Is<DateTime>(d => d == date))).Returns(false);
        TransactionsValidation transactionsValidation = new(mockTransactionService.Object);

        FileUploadViewModel fileUpload = new();
        string fileName = "exemplo.csv";
        var formFile = TestHelpers.GetFormFileFromStub(fileName);

        fileUpload.FormFile = formFile;

        IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

        var validatedList = transactionsValidation.Validate(list);

        Assert.Equal(6, validatedList.Count());
    }
}

