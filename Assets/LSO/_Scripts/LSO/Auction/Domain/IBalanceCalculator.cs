using System.Collections.Generic;
using LSO._Scripts.LSO.Auction.Person.Data;
using LSO._Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public interface IBalanceCalculator
    {
        public int CalcBalance(List<LSO_TaxidermyData> taxidermy, LSO_PersonSO person);
    }
}