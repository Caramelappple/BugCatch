using System;
using System.Collections.Generic;
using _Scripts.LSO.Auction.Person.Data;
using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public class AuctionEventPlayer
    {
        private readonly Action<List<LSO_PersonSO>, int, int> _onAuctionStart;
        private readonly Action<LSO_PersonSO, int, int> _onBid;
        private readonly Action<LSO_PersonSO> _onExit;
        private readonly Action<LSO_PersonSO, int> _onSuccess;
        private readonly Action<List<LSO_TaxidermyData>> _onFailed;
    }
}
