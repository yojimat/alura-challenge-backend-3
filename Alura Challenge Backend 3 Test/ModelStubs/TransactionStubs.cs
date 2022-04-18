using Alura_Challenge_Backend_3.Models;
using System;
using System.Collections.Generic;

namespace Alura_Challenge_Backend_3_Test.ModelStubs
{
    internal class TransactionStubs
    {
        private const string dateStringFormat = "yyyy-mm-ddThh:MM:ss";

        public readonly IReadOnlyList<Transaction> TransactionsStubs = new List<Transaction> {
            new() {
                OriginBank = "BANCO DO BRASIL",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 8000,
                DateTime = DateTime.ParseExact("2022-01-01T07:30:00", dateStringFormat, null)
            }
        };
    }
}
