using System.Collections.Generic;
using _Scripts.LSO.Auction.Person.Data;

namespace _Scripts.LSO.Auction.Event
{
    public class LSO_AuctionStartEvent : LSO_AuctionEvent
    {
        public readonly IReadOnlyList<LSO_PersonSO> Persons;
        public readonly int startPrice;
        public readonly int maxPrice;

        public LSO_AuctionStartEvent(IReadOnlyList<LSO_PersonSO> persons, int startPrice, int maxPrice)
        {
            Persons = persons;
            this.startPrice = startPrice;
            this.maxPrice = maxPrice;
        }
    }
}
