using System.Collections.Generic;
using LSO._Scripts.LSO.Auction.Person.Data;

namespace LSO._Scripts.LSO.Auction.Event
{
    public class LSO_AuctionStartEvent : LSO_AuctionEvent
    {
        public readonly IReadOnlyList<LSO_PersonSO> Persons;
        public readonly int StartPrice;
        public readonly int MaxPrice;

        public LSO_AuctionStartEvent(IReadOnlyList<LSO_PersonSO> persons, int startPrice, int maxPrice)
        {
            Persons = persons;
            this.StartPrice = startPrice;
            this.MaxPrice = maxPrice;
        }

        public override void Notify(IAuctionEventListener listener)
        {
            listener.AuctionStart(this);
        }
    }
}
