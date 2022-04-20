using Alura_Challenge_Backend_3.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Alura_Challenge_Backend_3.Models
{
    public class Transaction : ITransaction
    {
        private const string dateStringFormat = "yyyy-MM-ddTHH:mm:ss";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OriginBank { get; set; } = string.Empty;
        public int OriginAgency { get; set; }
        public string OriginAccount { get; set; } = string.Empty;

        public string DestinationBank { get; set; } = string.Empty;
        public int DestinationAgency { get; set; }
        public string DestinationAccount { get; set; } = string.Empty;

        public float Value { get; set; }
        public DateTime DateTime { get; set; }


        public static Transaction CreateTransactionByCsvLine(string line)
        {
            string[] arrayProp = line.Trim().Split(",");
            return new Transaction()
            {
                OriginBank = arrayProp[0],
                OriginAgency = int.Parse(arrayProp[1]),
                OriginAccount = arrayProp[2],

                DestinationBank = arrayProp[3],
                DestinationAgency = int.Parse(arrayProp[4]),
                DestinationAccount = arrayProp[5],

                Value = float.Parse(arrayProp[6]),
                DateTime = DateTime.ParseExact(arrayProp[7], dateStringFormat, CultureInfo.InvariantCulture)
            };
        }
    }
}
