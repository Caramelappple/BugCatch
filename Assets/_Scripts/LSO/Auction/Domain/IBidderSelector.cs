using System.Collections.Generic;
using _Scripts.LSO.Auction.Person.Data;

namespace _Scripts.LSO.Auction.Domain
{
    public interface IBidderSelector
    {
        public LSO_PersonSO SelectPerson(List<LSO_PersonSO> persons);
    }
}