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
        public float startRate = 0.6f;
        [Header("증가 비율")]
        public float increaseRate =  0.1f;
        [Header("최소 증가폭")]
        public int minIncrease = 3;
        [Header("상한가 기본값:3")]
        public float limitUpMulti = 3f;
        [Header("박제본 배율")] 
        public float taxidermyMulti = 1f;
    }
}