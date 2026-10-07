using System.Collections.Generic;
using LSO._Scripts.LSO.Auction.Person.Data;

namespace LSO._Scripts.LSO.Auction.Domain
{
    public interface IBidderSelector
    {
        public LSO_PersonSO SelectPerson(IReadOnlyList<BidCandidate> candidates);
    }
}