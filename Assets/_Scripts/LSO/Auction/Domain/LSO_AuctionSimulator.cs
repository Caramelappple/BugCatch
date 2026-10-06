using System.Collections.Generic;
using _Scripts.LSO.Auction.Person.Data;
using _Scripts.LSO.Auction.PersonTable;
using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public class LSO_AuctionSimulator
    {
        public LSO_AuctionConfigSO Config;
        
        public IBidderSelector Bidder {get; private set;}
        public ITaxidermyValueCalculator Taxidermy {get; private set;}
        public IBalanceCalculator Balance{get; private set;}
        
        public LSO_AuctionSimulator(IBidderSelector bidder, ITaxidermyValueCalculator taxidermy,
            IBalanceCalculator balance)
        {
            Bidder = bidder;
            Taxidermy = taxidermy;
            Balance = balance;
        }

        public AuctionResult Simulate(List<LSO_TaxidermyData> taxidermy, List<LSO_PersonSO> persons)
        {
            
        }
    }
}