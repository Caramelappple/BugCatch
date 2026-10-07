using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.LSO.Auction.Domain;
using _Scripts.LSO.Auction.PersonTable;
using LSO._Scripts.LSO.Auction.Event;
using LSO._Scripts.LSO.Auction.Person.Data;
using LSO._Scripts.LSO.Taxidermy;
using UnityEngine;

namespace LSO._Scripts.LSO.Auction.Domain
{
    public class LSO_AuctionSimulator
    {
        public LSO_AuctionConfigSO Config;

        //사람 골라주는 것
        public IBidderSelector BidderSlc { get; private set; }

        //박제본 가치 계산
        public ITaxidermyValueCalculator TaxidermyCalc { get; private set; }

        //잔고 계산
        public IBalanceCalculator BalanceCalc { get; private set; }

        public IAuctionEventListener EventListener { get; private set; }

        public LSO_AuctionSimulator(IBidderSelector bidderSlc, ITaxidermyValueCalculator taxidermyCalc,
            IBalanceCalculator balanceCalc, LSO_AuctionConfigSO config)
        {
            BidderSlc = bidderSlc;
            TaxidermyCalc = taxidermyCalc;
            BalanceCalc = balanceCalc;
            Config = config;
            
        }

        public AuctionResult Simulate(List<LSO_TaxidermyData> bundle, List<LSO_PersonSO> persons)
        {
            LSO_PersonSO first = null;

            List<LSO_AuctionEvent> auctionEvents = new List<LSO_AuctionEvent>();

            int currentV = 0;
            int totalV = GetTotal(bundle);
            int startV = GetStart(totalV);
            int unitV = GetUnit(startV);
            int maxV = GetMax(totalV);

            var candidates = CalcPartiBalance(bundle, persons);

            auctionEvents.Add(new LSO_AuctionStartEvent(persons, startV, maxV));

            ExitParti(candidates, first, startV, auctionEvents);
            if (candidates.Count == 0)
                return CreateResult(first, bundle, currentV, auctionEvents);

            first = BidderSlc.SelectPerson(CollectCandidate(candidates, first));
            currentV = startV;
            auctionEvents.Add(new LSO_BidEvent(first, currentV));
            

            while (true)
            {
                int nextBid = CalcNextBid(currentV, unitV, maxV);
                
                if (currentV == nextBid)
                {
                    break;
                }
                ExitParti(candidates, first, nextBid, auctionEvents);
                
                List<BidCandidate> bidCandidates = CollectCandidate(candidates, first);
                
                if (bidCandidates.Count == 0) 
                    break;
                
                first = BidderSlc.SelectPerson(bidCandidates);
                currentV = nextBid;
                auctionEvents.Add(new LSO_BidEvent(first, currentV));
            }
            
            return CreateResult(first, bundle, currentV, auctionEvents);
        }


        #region 시작가·입찰 단위·상한 계산

        private int GetStart(int total)
            => CeilRounded(total * (double)Config.startRate);

        private int GetUnit(int start)
            => Mathf.Max(CeilRounded(start * (double)Config.increaseRate), Config.minIncrease);

        private int GetMax(int total)
            => CeilRounded(total * (double)Config.limitUpMulti);

        private int GetTotal(List<LSO_TaxidermyData> bundle)
        {
            int total = 0;
            foreach (LSO_TaxidermyData taxidermyData in bundle)
            {
                total += TaxidermyCalc.CalcValue(taxidermyData);
            }

            return total;
        }

        private int CeilRounded(double value)
            => (int)Math.Ceiling(Math.Round(value, 2));

        #endregion

        private List<BidCandidate> CalcPartiBalance(List<LSO_TaxidermyData> bundle, List<LSO_PersonSO> persons)
        {
            List<BidCandidate> candidates = new List<BidCandidate>();

            foreach (var p in persons)
            {
                candidates.Add(
                    new BidCandidate(BalanceCalc.CalcBalance(bundle, p),
                        p)
                );
            }

            return candidates;
        }

        private int CalcNextBid(int cur, int unit, int max)
        {
            return Math.Min(cur + unit, max);
        }

        //중복이 막아져있어서 SO로 충분히 구분 가능하다
        private List<BidCandidate> ExitParti(List<BidCandidate> candidates, LSO_PersonSO first
            , int nextValue, List<LSO_AuctionEvent> auctionEvent)
        {
            foreach (BidCandidate c in candidates.ToList())
            {
                if (c.Balance < nextValue)
                {
                    if (first == c.Person)
                        continue;
                    candidates.Remove(c);
                    auctionEvent.Add(new LSO_ExitEvent(c.Person));
                }
            }
            return candidates;
        }

        private List<BidCandidate> CollectCandidate(List<BidCandidate> candidates, LSO_PersonSO first)
        {
            List<BidCandidate> result = new List<BidCandidate>();

            foreach (var candidate in candidates)
            {
                if (candidate.Person != first)
                    result.Add(candidate);
            }
            
            return result;
        }
        
        private AuctionResult CreateResult(LSO_PersonSO first, List<LSO_TaxidermyData> bundle, int currentV, List<LSO_AuctionEvent> auctionEvents)
        {
            if (first == null)
                auctionEvents.Add(new LSO_FailedEvent(bundle));
            else
                auctionEvents.Add(new LSO_SuccessEvent(first, currentV));
            
            bool failed = first == null;

            return new AuctionResult(first, bundle, currentV, failed , auctionEvents);

        }
    }
}