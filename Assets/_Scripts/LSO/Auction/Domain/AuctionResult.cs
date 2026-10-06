using System.Collections.Generic;
using _Scripts.LSO.Auction.Person.Data;
using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public readonly struct AuctionResult
    {
        public readonly LSO_PersonSO Persons;
        public readonly List<LSO_TaxidermyData> SoldGroup;
        public readonly int SoldPrice;
        public readonly bool Failed;

        public AuctionResult(LSO_PersonSO pickedPerson, List<LSO_TaxidermyData> soldGroup, int soldPrice, bool failed = false)
        {
            Persons = pickedPerson;
            SoldGroup = soldGroup;
            SoldPrice = soldPrice;
            Failed = failed;
        }
    }
}