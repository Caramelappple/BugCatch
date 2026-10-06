using _Scripts.LSO.Auction.Person.Data;

namespace _Scripts.LSO.Auction.Event
{
    public class LSO_SuccessEvent : LSO_AuctionEvent
    {
        public readonly LSO_PersonSO winner;
        public readonly int resultPrice;

        public LSO_SuccessEvent(LSO_PersonSO winner, int resultPrice)
        {
            this.winner = winner;
            this.resultPrice = resultPrice;
        }
    }
}
