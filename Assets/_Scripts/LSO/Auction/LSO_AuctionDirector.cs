using System.Collections.Generic;
using _Scripts.LSO.Auction.Data;
using _Scripts.LSO.Auction.Person;
using UnityEngine;

namespace _Scripts.LSO.Auction
{
    public class LSO_AuctionDirector : MonoBehaviour
    {
        public LSO_PersonTable personTable;
        public LSO_AuctionStartEffect StartEffect;
        public LSO_Auction Auction;
        public LSO_AuctionSuccessEffect SuccessEffect;
        
        private List<LSO_PersonSO> _pickedPersons;

        private void Awake()
        {
            if (personTable == null)
                Debug.LogError("LSO_AuctionDirector: personTable is null");
            if (StartEffect == null)
                Debug.LogError("LSO_AuctionDirector: StartEffect is null");
            if (SuccessEffect == null)
                Debug.LogError("LSO_AuctionDirector: SuccessEffect is null");
            if (Auction == null)
                Debug.LogError("LSO_AuctionDirector: Auction is null");
        }

        public void StartAuction()
        {
            _pickedPersons ??= LSO_ItemWeightPicker.PickMany(personTable.maxPeoplePerRounds, personTable.Persons);
            
            
        }
    }
}
