using LSO._Scripts.LSO.Auction.Person.Data;

namespace LSO._Scripts.LSO.Auction.Event
{
    public class LSO_BidEvent : LSO_AuctionEvent
    {
        public readonly LSO_PersonSO Person;
        public readonly int BidPrice;

        public LSO_BidEvent(LSO_PersonSO person, int bidPrice)
        {
            this.Person = person;
            this.BidPrice = bidPrice;
        }

        public override void Notify(IAuctionEventListener listener)
        {
            listener.Bid(this);
        }
    }
}
