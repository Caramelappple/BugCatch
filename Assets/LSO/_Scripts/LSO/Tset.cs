using System.Collections.Generic;
using _Scripts.LSO.Auction.Domain;
using _Scripts.LSO.Auction.PersonTable;
using _Scripts.LSO.Bug.Data;
using LSO._Scripts.LSO;
using LSO._Scripts.LSO.Auction;
using LSO._Scripts.LSO.Auction.Domain;
using LSO._Scripts.LSO.Auction.Event;
using LSO._Scripts.LSO.Auction.Person.Data;
using LSO._Scripts.LSO.Auction.View;
using LSO._Scripts.LSO.Bug;
using LSO._Scripts.LSO.Taxidermy;
using UnityEngine;

public class LSO_AuctionSimTester : MonoBehaviour
{
    [SerializeField] private LSO_AuctionConfigSO config;
    [SerializeField] private LSO_PersonTableSO personTable;
    [SerializeField] private List<LSO_BugSO> bugs;
    [SerializeField, Range(0f, 1f)] private float pinAccuracy = 1f;
    [SerializeField, Min(1)] private int runs = 100;

    [ContextMenu("Run Auction Test")]
    private void Run()
    {
        var valueCalc = new LSO_TaxidermyValueCalculator(config);
        IBalanceCalculator balanceCalc = new LSO_BalanceCalculator(valueCalc);
        var sim = new LSO_AuctionSimulator(new LSO_BidderSelector(), valueCalc, balanceCalc, config);

        int sold = 0, failed = 0, errors = 0;
        for (int i = 0; i < runs; i++)
        {
            var persons = LSO_ItemWeightPicker.PickMany(config.maxPeople, personTable.Persons);
            var bundle = MakeBundle();
            var result = sim.Simulate(bundle, persons);

            errors += Validate(result, bundle, balanceCalc, config.minIncrease);
            if (result.Failed) failed++; else sold++;

            // 첫 판만 이벤트 로그를 출력해서 눈으로 확인
            if (i == 0)
                new AuctionEventPlayer(result.Events, new LSO_AuctionDebugListener()).Skip();
        }

        Debug.Log($"[Test] runs={runs} sold={sold} failed={failed} errors={errors}");
    }

    private List<LSO_TaxidermyData> MakeBundle()
    {
        var bundle = new List<LSO_TaxidermyData>();
        for (int i = 0; i < bugs.Count && i < config.maxProducts; i++)
            bundle.Add(new LSO_TaxidermyData(new LSO_BugInstance(bugs[i]), pinAccuracy));
        return bundle;
    }

    private int Validate(AuctionResult r, List<LSO_TaxidermyData> bundle,
        IBalanceCalculator balanceCalc, int minIncrease)
    {
        int errors = 0;
        void Fail(string msg) { errors++; Debug.LogError("[Test] " + msg); }

        var ev = r.Events;
        if (ev == null || ev.Count == 0) { Fail("이벤트가 없음"); return errors; }

        var start = ev[0] as LSO_AuctionStartEvent;
        if (start == null) { Fail("첫 이벤트가 시작 이벤트가 아님"); return errors; }

        var exited = new HashSet<LSO_PersonSO>();
        LSO_PersonSO leader = null;
        int last = 0, bids = 0, finals = 0;

        for (int i = 1; i < ev.Count; i++)
        {
            if (finals > 0) Fail("최종 이벤트 뒤에 이벤트가 더 있음");

            switch (ev[i])
            {
                case LSO_ExitEvent e:
                    if (!exited.Add(e.Person)) Fail($"{e.Person.personName} 퇴장 중복");
                    if (e.Person == leader) Fail($"선두 {e.Person.personName}가 퇴장함");
                    break;

                case LSO_BidEvent b:
                    if (exited.Contains(b.Person)) Fail($"퇴장한 {b.Person.personName}가 입찰함");
                    if (b.Person == leader) Fail($"{b.Person.personName}가 연속 입찰함");
                    if (b.BidPrice > start.MaxPrice) Fail($"입찰가 {b.BidPrice}가 상한 {start.MaxPrice} 초과");
                    if (balanceCalc.CalcBalance(bundle, b.Person) < b.BidPrice)
                        Fail($"{b.Person.personName}가 잔고보다 높은 {b.BidPrice}로 입찰함");

                    if (bids == 0)
                    {
                        if (b.BidPrice != start.StartPrice)
                            Fail($"첫 입찰가 {b.BidPrice}가 시작가 {start.StartPrice}와 다름");
                    }
                    else
                    {
                        int diff = b.BidPrice - last;
                        if (diff <= 0) Fail($"입찰가가 오르지 않음 ({last} → {b.BidPrice})");
                        else if (diff < minIncrease && b.BidPrice != start.MaxPrice)
                            Fail($"증가폭 {diff}가 최소 증가폭 {minIncrease} 미만");
                    }
                    last = b.BidPrice;
                    leader = b.Person;
                    bids++;
                    break;

                case LSO_SuccessEvent s:
                    finals++;
                    if (bids == 0) Fail("입찰 없이 낙찰됨");
                    if (s.Winner != leader) Fail("낙찰자가 마지막 선두와 다름");
                    if (s.ResultPrice != last) Fail($"낙찰가 {s.ResultPrice}가 마지막 입찰가 {last}와 다름");
                    if (r.Failed) Fail("낙찰 이벤트인데 결과가 유찰");
                    if (r.SoldPrice != s.ResultPrice) Fail("결과의 낙찰가가 이벤트와 다름");
                    break;

                case LSO_FailedEvent _:
                    finals++;
                    if (bids != 0) Fail("입찰이 있었는데 유찰됨");
                    if (!r.Failed) Fail("유찰 이벤트인데 결과가 낙찰");
                    break;
            }
        }

        if (finals != 1) Fail($"최종 이벤트 개수가 {finals}개 (1개여야 함)");
        return errors;
    }
}