using System.Collections.Generic;
using _Scripts.LSO.Auction.Event;
using _Scripts.LSO.Auction.Person.Data;
using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public readonly struct AuctionResult
    {
        public readonly LSO_PersonSO Winner;
        public readonly IReadOnlyList<LSO_TaxidermyData> SoldGroup;
        public readonly int SoldPrice;
        public readonly bool Failed;
        public readonly IReadOnlyList<LSO_AuctionEvent> Events;

        public AuctionResult(LSO_PersonSO pickedWinner, List<LSO_TaxidermyData> soldGroup, int soldPrice,
            bool failed = false, IReadOnlyList<LSO_AuctionEvent> events = null)
        {
            Winner = pickedWinner;
            SoldGroup = soldGroup;
            SoldPrice = soldPrice;
            Failed = failed;
            Events = events;

            if (failed)
            {
                Winner = null;
                SoldPrice = 0;
            }
        }
    }
}
