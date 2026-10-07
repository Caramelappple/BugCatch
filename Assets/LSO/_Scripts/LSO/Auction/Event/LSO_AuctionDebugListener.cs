using System.Security.Cryptography;
using UnityEngine;

namespace LSO._Scripts.LSO.Auction.Event
{
    public class LSO_AuctionDebugListener : IAuctionEventListener
    {
        public void AuctionStart(LSO_AuctionStartEvent auctionEvent)
        {
            Debug.Log("경매 시작됨");
        }

        public void Bid(LSO_BidEvent auctionEvent)
        {
            Debug.Log( "[Auction]"+auctionEvent.BidPrice.ToString());
        }

        public void Exit(LSO_ExitEvent auctionEvent)
        {
            Debug.Log(auctionEvent.Person + "나감");
        }

        public void Success(LSO_SuccessEvent auctionEvent)
        {
           Debug.Log($"{auctionEvent.Winner} {auctionEvent.ResultPrice}");
        }

        public void Fail(LSO_FailedEvent auctionEvent)
        {
            Debug.Log("유찰됨");
        }
    }
}