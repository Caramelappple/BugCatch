using System.Collections.Generic;
using _Scripts.LSO.Auction.Domain;
using _Scripts.LSO.Auction.Person;
using _Scripts.LSO.Auction.Person.Data;
using _Scripts.LSO.Auction.PersonTable;
using UnityEngine;

namespace _Scripts.LSO.Auction.View
{
    public class LSO_AuctionDirector : MonoBehaviour
    {
        public LSO_PersonTableSO personTableSo;
        public LSO_AuctionStartEffect StartEffect;
        public LSO_AuctionSimulator AuctionSimulator;
        public LSO_AuctionSuccessEffect SuccessEffect;
        public LSO_AuctionConfigSO config;
        
        private List<LSO_PersonSO> _pickedPersons;

        private void Awake()
        {
            Debug.Assert(_pickedPersons != null);
            Debug.Assert(_pickedPersons.Count > 0);
            Debug.Assert(_pickedPersons.Count == personTableSo.Persons.Count);
            Debug.Assert(_pickedPersons.Count == personTableSo.Persons.Count);
        }

        public void StartAuction()
        {
            _pickedPersons ??= LSO_ItemWeightPicker.PickMany(config.maxPeople, personTableSo.Persons);
        }
    }
}
