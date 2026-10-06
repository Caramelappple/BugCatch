using System.Collections.Generic;
using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Event
{
    public class LSO_FailedEvent : LSO_AuctionEvent
    {
        public readonly IReadOnlyList<LSO_TaxidermyData> taxidermyData;

        public LSO_FailedEvent(IReadOnlyList<LSO_TaxidermyData> taxidermyData)
        {
            this.taxidermyData = taxidermyData;
        }
    }
}
