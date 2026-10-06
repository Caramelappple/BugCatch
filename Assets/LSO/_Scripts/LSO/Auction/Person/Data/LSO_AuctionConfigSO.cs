using UnityEngine;

namespace _Scripts.LSO.Auction.PersonTable
{
    [CreateAssetMenu(fileName = "AuctionConfigSO", menuName = "LSO/AuctionConfigSO")]
    public class LSO_AuctionConfigSO : ScriptableObject
    {
        [Header("최대 참가자")]
        public int maxPeople = 6;
        [Header("최소 참가자")]
        public int minPeople = 6;
        [Header("최대 상품수")]
        public int maxProducts = 6;
        [Header("시작 비율")]
        public float startPercent = 60f;
        [Header("증가 비율")]
        public float increasePercent =  10f;
        [Header("최소 증가폭")]
        public int minIncrease = 3;
        [Header("상한가 기본값:3")]
        public int limitUpMulti = 3;
    }
}