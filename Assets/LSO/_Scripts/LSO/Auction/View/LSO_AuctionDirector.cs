using System.Collections.Generic;
using _Scripts.LSO.Auction.Domain;
using _Scripts.LSO.Auction.PersonTable;
using LSO._Scripts.LSO;
using LSO._Scripts.LSO.Auction;
using LSO._Scripts.LSO.Auction.Domain;
using LSO._Scripts.LSO.Auction.Event;
using LSO._Scripts.LSO.Auction.Person.Data;
using LSO._Scripts.LSO.Auction.View;
using LSO._Scripts.LSO.Taxidermy;
using UnityEngine;

namespace _Scripts.LSO.Auction.View
{
    public class LSO_AuctionDirector : MonoBehaviour
    {
        [SerializeField] private LSO_AuctionConfigSO config;
        [SerializeField] private LSO_PersonTableSO personTableSo;
        [SerializeField]private List<LSO_PersonSO> pickedPersons;
      
        private IBalanceCalculator _balanceCalculator;
        private IBidderSelector _bidderSelector;
        private ITaxidermyValueCalculator _taxidermyValueCalculator;
        private LSO_AuctionSimulator _auctionSimulator;
        private IAuctionEventListener _auctionEventListener;
        
        private LSO_AuctionStartEffect _startEffect;
        private LSO_AuctionSuccessEffect _successEffect;
        
        private void Awake()
        {
           Assembly();
        }

        private void Assembly()
        {
            _taxidermyValueCalculator = new LSO_TaxidermyValueCalculator(config);
            _balanceCalculator = new LSO_BalanceCalculator(_taxidermyValueCalculator);
            _bidderSelector = new LSO_BidderSelector();
            _auctionSimulator = new LSO_AuctionSimulator(
                _bidderSelector
                , _taxidermyValueCalculator
                ,_balanceCalculator
                ,config);
            _auctionEventListener = new LSO_AuctionDebugListener();
        }

        public void StartAuction(List<LSO_TaxidermyData> bundle)
        {
            pickedPersons ??= LSO_ItemWeightPicker.PickMany(config.maxPeople, personTableSo.Persons);
            AuctionResult result = _auctionSimulator.Simulate(bundle, pickedPersons);
            AuctionEventPlayer auctionEventPlayer = new AuctionEventPlayer(result.Events, _auctionEventListener);
        }
    }
}
