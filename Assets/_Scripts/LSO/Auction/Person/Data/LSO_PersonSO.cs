using _Scripts.LSO.Auction.Data.Taste;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data
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
        public LSO_TasteSO Taste;
        [Header("가격 제시/포기/성공 시 뜨는 텍스트 목록")]
        public LSO_PersonTextSO personText;
        [Header("등장 가중치 (높을수록 잘 나옴)")]
        [Min(0)] public int spawnWeight = 10; // 기본값 설정
    }
}