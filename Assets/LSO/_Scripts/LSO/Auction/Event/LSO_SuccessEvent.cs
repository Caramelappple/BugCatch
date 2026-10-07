using LSO._Scripts.LSO.Auction.Person.Data;

namespace LSO._Scripts.LSO.Auction.Event
{
    public class LSO_SuccessEvent : LSO_AuctionEvent
    {
        public readonly LSO_PersonSO Winner;
        public readonly int ResultPrice;

        public LSO_SuccessEvent(LSO_PersonSO winner, int resultPrice)
        {
            this.Winner = winner;
            this.ResultPrice = resultPrice;
        }

        public override void Notify(IAuctionEventListener listener)
        {
            listener.Success(this);
        }
    }
}
