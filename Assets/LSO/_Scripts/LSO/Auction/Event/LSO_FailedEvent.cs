using System.Collections.Generic;
using LSO._Scripts.LSO.Taxidermy;

namespace LSO._Scripts.LSO.Auction.Event
{
    public class LSO_FailedEvent : LSO_AuctionEvent
    {
        public readonly IReadOnlyList<LSO_TaxidermyData> TaxidermyData;

        public LSO_FailedEvent(IReadOnlyList<LSO_TaxidermyData> taxidermyData)
        {
            this.TaxidermyData = taxidermyData;
        }

        public override void Notify(IAuctionEventListener listener)
        {
            listener.Fail(this);
        }
    }
}
