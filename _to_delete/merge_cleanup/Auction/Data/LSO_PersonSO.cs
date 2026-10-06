using _Scripts.LSO.Auction.Data;
using _Scripts.LSO.Auction.Taste.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Person.Data
{
    /// <summary>
    /// 참가자의 정보들을 가지고 있는 SO
    /// </summary>
    [CreateAssetMenu(fileName = "New PersonSO", menuName = "LSO/Auction/PersonSO", order = 0)]
    public sealed class LSO_PersonSO : LSO_WeightableSO
    {
        [Header("참가자의 이름")]
        public string personName;
        [Header("벌레 취향(취향이 맞을 시 가격에 보너스가 붙음)")]
        public LSO_TasteSO taste;
        [Header("가격 제시/포기/성공 시 뜨는 텍스트 목록")]
        public LSO_PersonTextSO personText;
        [Header("등장 가중치 (높을수록 잘 나옴)")]
        [Min(1)] public int appearWeight = 10; // 기본값 설정
        [Header("잔고배율")]
        public float balance;
    }
}