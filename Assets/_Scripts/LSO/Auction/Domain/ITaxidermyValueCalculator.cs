using _Scripts.LSO.Bug;
using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public interface ITaxidermyValueCalculator
    {
        public int CalcValue(LSO_TaxidermyData taxidermyData);
    }
}