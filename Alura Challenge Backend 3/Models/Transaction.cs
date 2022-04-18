namespace Alura_Challenge_Backend_3.Models
{
    public class Transaction
    {
        public string OriginBank { get; set; }
        public int OriginAgency { get; set; }
        public string OriginAccount { get; set; }

        public string DestinationBank { get; set; }
        public int DestinationAgency { get; set; }
        public string DestinationAccount { get; set; }

        public float Value { get; set; }
        public DateTime DateTime { get; set; }
    }
}
