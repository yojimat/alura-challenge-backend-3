using Alura_Challenge_Backend_3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Alura_Challenge_Backend_3_Test.ModelStubs
{
    internal static class TransactionStubs
    {
        private const string dateStringFormat = "yyyy-MM-ddThh:mm:ss";

        public static readonly IReadOnlyList<Transaction> TransactionsListStub = new List<Transaction> {
            new() {
                OriginBank = "BANCO DO BRASIL",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 8000,
                DateTime = DateTime.ParseExact("2022-01-01T07:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            }
        };
    }
}
