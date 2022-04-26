using Alura_Challenge_Backend_3.Models;
using Alura_Challenge_Backend_3.Models.EqualityComparers;
using Alura_Challenge_Backend_3_Test.Helpers;
using Alura_Challenge_Backend_3_Test.ModelStubs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Alura_Challenge_Backend_3_Test;

public class FileUploadTest
{
    [Fact]
    public void Should_Return_A_List_Of_Transactions()
    {
        FileUploadViewModel fileUpload = new();
        string fileName = "transacoes-2022-01-01.csv";
        var formFile = TestHelpers.GetFormFileFromStub(fileName);

        fileUpload.FormFile = formFile;

        IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

        Assert.NotNull(list);
        Assert.True(list.SequenceEqual(TransactionStubs.TransactionsListStub, new TransactionEqualityComparer()));
    }

    [Fact]
    public void Should_Return_Empty_List_When_No_File_Is_Send()
    {
        FileUploadViewModel fileUpload = new();

        IEnumerable<Transaction> list = fileUpload.ReadCSVFile();

        Assert.NotNull(list);
        Assert.Empty(list);
    }

    [Fact]
    public void Should_Ignore_Wrong_Files_Format()
    {
        FileUploadViewModel fileUpload = new();
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
