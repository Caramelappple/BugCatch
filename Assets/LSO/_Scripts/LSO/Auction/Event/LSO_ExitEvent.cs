using _Scripts.LSO.Auction.Person.Data;

namespace _Scripts.LSO.Auction.Event
{
    public class LSO_ExitEvent : LSO_AuctionEvent
    {
        public readonly LSO_PersonSO person;

        public LSO_ExitEvent(LSO_PersonSO person)
        {
            this.person = person;
        }
    }
}
