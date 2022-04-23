using Alura_Challenge_Backend_3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Alura_Challenge_Backend_3_Test.ModelStubs
{
    internal static class TransactionStubs
    {
        private const string dateStringFormat = "yyyy-MM-ddTHH:mm:ss";

        public static readonly IEnumerable<Transaction> TransactionsListStub = new List<Transaction> {
            new() {
                OriginBank = "BANCO DO BRASIL",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 8000,
                DateTime = DateTime.ParseExact("2022-01-01T07:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO SANTANDER",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 210,
                DateTime = DateTime.ParseExact("2022-01-01T08:12:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO SANTANDER",
                OriginAgency = 0001,
                OriginAccount = "00002-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 79800.22,
                DateTime = DateTime.ParseExact("2022-01-01T08:44:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO BRADESCO",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO SANTANDER",
                DestinationAgency = 0001,
                DestinationAccount = "00002-1",

                Value = 11.50,
                DateTime = DateTime.ParseExact("2022-01-01T12:32:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO BANRISUL",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 100,
                DateTime = DateTime.ParseExact("2022-01-01T16:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO ITAU",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 19000.50,
                DateTime = DateTime.ParseExact("2022-01-01T16:55:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO ITAU",
                OriginAgency = 0001,
                OriginAccount = "00002-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 1000,
                DateTime = DateTime.ParseExact("2022-01-01T19:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "NUBANK",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 2000,
                DateTime = DateTime.ParseExact("2022-01-01T19:34:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "BANCO INTER",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 300,
                DateTime = DateTime.ParseExact("2022-01-01T20:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            },
            new() {
                OriginBank = "CAIXA ECONOMICA FEDERAL",
                OriginAgency = 0001,
                OriginAccount = "00001-1",

                DestinationBank = "BANCO BRADESCO",
                DestinationAgency = 0001,
                DestinationAccount = "00001-1",

                Value = 900,
                DateTime = DateTime.ParseExact("2022-01-01T22:30:00", dateStringFormat, CultureInfo.InvariantCulture)
            }

        };
    }
}
