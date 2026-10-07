using LSO._Scripts.LSO.Auction.Person.Data;

namespace LSO._Scripts.LSO.Auction.Event
{
    public class LSO_ExitEvent : LSO_AuctionEvent
    {
        public readonly LSO_PersonSO Person;

        public LSO_ExitEvent(LSO_PersonSO person)
        {
            this.Person = person;
        }

        public override void Notify(IAuctionEventListener listener)
        {
            listener.Exit(this);
        }
    }
}
