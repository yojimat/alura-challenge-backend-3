namespace Alura_Challenge_Backend_3.Models.EqualityComparers
{
    public class TransactionEqualityComparer : IEqualityComparer<Transaction>
    {
        public bool Equals(Transaction? t1, Transaction? t2)
        {
            if (t2 == null && t1 == null)
                return true;
            else if (t1 == null || t2 == null)
                return false;
            else if (t1.DestinationBank == t2.DestinationBank
                     && t1.DestinationAccount == t2.DestinationAccount
                     && t1.DestinationAgency == t2.DestinationAgency
                     && t1.OriginBank == t2.OriginBank
                     && t1.OriginAccount == t2.OriginAccount
                     && t1.OriginAgency == t2.OriginAgency
                     && t1.DateTime == t2.DateTime
                     && t1.Value == t2.Value
                )
                return true;
            else
                return false;
        }

        public int GetHashCode(Transaction tx)
        {
            int hCode = tx.DestinationAgency ^ (int)tx.Value ^ tx.OriginAgency ^ (int)tx.Value;
            return hCode.GetHashCode();
        }

    }
}
