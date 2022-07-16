using Alura_Challenge_Backend_3.Models;
using Alura_Challenge_Backend_3_Test.ModelStubs;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Alura_Challenge_Backend_3_Test;

public class TransactionTests
{
    [Fact]
    public void Should_Insert_UserId_In_A_Transaction_List()
    {
        int registerId = 7;
        string dateStringFormat = "yyyy-MM-ddTHH:mm:ss";
        IEnumerable<Transaction> transactionList = new List<Transaction> {
            new() {
                OriginBank = "BANCO DO BRASIL",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 8000,
                DateTime = DateTime.ParseExact("2022-01-01T07:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            } };

        Transaction.InsertUserId(transactionList, registerId);

        foreach (var item in transactionList)
        {
            Assert.Equal(item.UserId, registerId);
        }
    }
}


