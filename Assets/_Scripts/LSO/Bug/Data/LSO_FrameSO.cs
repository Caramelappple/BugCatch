using UnityEngine;

namespace _Scripts.LSO.Bug.Data
{
    [CreateAssetMenu(fileName = "New FrameSO", menuName = "LSO/Bug/FrameSO", order = 0)]
    public class LSO_FrameSO : ScriptableObject
    {
        // 프레임 이름
        public string frameName;
        //프레임 스프라이트
        public Sprite frameSprite;
        //구매 가격
        public int defaultPrice;
        //박제본에 부여하는 보너스 머니
        public int bonusPrice;
        //박제본에 곱해주는 보너스 멀티플라이어
        public int bonusMultiplier;
        ////곱하기 먼저 연산하기 여부(기본값 false: 나중에 곱하기)
        //public bool multiFirst;
        //프레임의 희귀도
        public LSO_RarityEnum rarity;
    }
}