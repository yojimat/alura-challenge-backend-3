﻿namespace Alura_Challenge_Backend_3.Models.Interfaces
{
    public interface ITransaction
    {
        static Transaction CreateTransactionByCsvLine(string line)
        {
            return new Transaction();
        }
    }
}