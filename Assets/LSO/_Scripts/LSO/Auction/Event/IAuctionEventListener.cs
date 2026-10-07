namespace LSO._Scripts.LSO.Auction.Event
{
    public interface IAuctionEventListener
    {
        public void AuctionStart(LSO_AuctionStartEvent auctionEvent);
        public void Bid(LSO_BidEvent auctionEvent);
        public void Exit(LSO_ExitEvent auctionEvent);
        public void Success(LSO_SuccessEvent auctionEvent);
        public void Fail(LSO_FailedEvent auctionEvent);
    }
}