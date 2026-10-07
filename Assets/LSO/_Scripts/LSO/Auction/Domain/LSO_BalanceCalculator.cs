using System.Collections.Generic;
using _Scripts.LSO.Auction.Domain;
using _Scripts.LSO.Auction.Taste.Data;
using LSO._Scripts.LSO.Auction.Person.Data;
using LSO._Scripts.LSO.Taxidermy;
using UnityEngine;

namespace LSO._Scripts.LSO.Auction.Domain
{
    /// <summary>
    /// 잔고 계산해주는 스크립트
    /// </summary>
    public class LSO_BalanceCalculator : IBalanceCalculator
    {
        private readonly ITaxidermyValueCalculator _taxidermyCalc;
        
        //디렉터가 생성자 호출해서 가져오기
        public LSO_BalanceCalculator(ITaxidermyValueCalculator taxidermyCalc)
        {
            _taxidermyCalc = taxidermyCalc;
        }
        
        
        public int CalcBalance(List<LSO_TaxidermyData> taxidermy, LSO_PersonSO person)
        {
            //묶음 가치 × 참가자 배율을 계산하고, (2) 맞는 박제 각각의 가치 × 보너스 비율을 더하고, (3) 정수로 올려 반환합니다

            float bundleValue = 0;

            foreach (var tData in taxidermy)
            {
                bundleValue += _taxidermyCalc.CalcValue(tData);
            }

            float total = bundleValue * person.balance;

            foreach (var tData in FilterTaxidermy(person.taste,taxidermy))
            {
                total += _taxidermyCalc.CalcValue(tData) * person.taste.bonusRate;
            }

            total -= 0.0001f;
            return Mathf.CeilToInt(total);
        }
        
        private List<LSO_TaxidermyData> FilterTaxidermy(LSO_TasteSO taste, List<LSO_TaxidermyData> taxidermyData)
        {
            List<LSO_TaxidermyData> compareTastes = new List<LSO_TaxidermyData>();
            
            if (taste == null)
                return compareTastes;
            
            foreach (var tx in taxidermyData)
            {
                if (taste.IsTasteComfort(tx.Bug))
                    compareTastes.Add(tx);
            }
            
            return compareTastes;
        }
    }
}