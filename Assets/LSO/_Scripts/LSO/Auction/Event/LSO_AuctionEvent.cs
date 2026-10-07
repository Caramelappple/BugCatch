namespace LSO._Scripts.LSO.Auction.Event
{
    public abstract class LSO_AuctionEvent
    {
        public abstract void Notify(IAuctionEventListener listener);
    }
}
