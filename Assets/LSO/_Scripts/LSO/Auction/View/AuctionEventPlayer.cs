using System.Collections.Generic;
using LSO._Scripts.LSO.Auction.Event;

namespace LSO._Scripts.LSO.Auction.View
{
    public class AuctionEventPlayer
    {
        private readonly IReadOnlyList<LSO_AuctionEvent> AuctionEvents;
        public readonly IAuctionEventListener AuctionEventListener;
        private int CurPos;

        public bool HasNext { get; private set; } = true;
        
        public AuctionEventPlayer(IReadOnlyList<LSO_AuctionEvent> auctionEvents, IAuctionEventListener auctionEventListener)
        {   
            AuctionEvents = auctionEvents;
            AuctionEventListener = auctionEventListener;
        }

        public void Next()
        {
            AuctionEvents[CurPos].Notify(AuctionEventListener);
            //이게 메모리 덜 잡아 먹음
            CurPos++;
            if (CurPos >= AuctionEvents.Count)
                HasNext = false;
        }
        
        //건너뛰기 용
        public void Skip()
        {
            while (HasNext)
                Next();
        }
    }
}