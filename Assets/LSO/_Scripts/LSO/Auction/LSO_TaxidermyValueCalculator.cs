using _Scripts.LSO.Auction.Domain;
using _Scripts.LSO.Auction.PersonTable;
using LSO._Scripts.LSO.Taxidermy;
using UnityEngine;

namespace LSO._Scripts.LSO.Auction
{
    public class LSO_TaxidermyValueCalculator : ITaxidermyValueCalculator
    {
        private readonly LSO_AuctionConfigSO _config;

        public LSO_TaxidermyValueCalculator(LSO_AuctionConfigSO config)
        {
            _config = config;
        }
        
        public int CalcValue(LSO_TaxidermyData taxidermyData)
        {
            int bugPrice = taxidermyData.Bug.Bug.defaultPrice;
            float pinAccuracy = taxidermyData.PinAccuracy;
            float taxidermyMulti = _config.taxidermyMulti;

            return Mathf.CeilToInt(bugPrice * pinAccuracy * taxidermyMulti);
        }
    }
}