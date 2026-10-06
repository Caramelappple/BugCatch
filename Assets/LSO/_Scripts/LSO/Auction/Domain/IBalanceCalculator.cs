using _Scripts.LSO.Taxidermy;

namespace _Scripts.LSO.Auction.Domain
{
    public interface IBalanceCalculator
    {
        public int CalcBalance(LSO_TaxidermyData[]  taxidermyData);
    }
}