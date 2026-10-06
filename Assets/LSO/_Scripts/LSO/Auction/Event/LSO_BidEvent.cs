using _Scripts.LSO.Auction.Person.Data;

namespace _Scripts.LSO.Auction.Event
{
    public class LSO_BidEvent : LSO_AuctionEvent
    {
        public readonly LSO_PersonSO person;
        public readonly int bidPrice;

        public LSO_BidEvent(LSO_PersonSO person, int bidPrice)
        {
            this.person = person;
            this.bidPrice = bidPrice;
        }
    }
}
