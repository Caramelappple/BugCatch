using _Scripts.LSO.Auction.Taste.Character;
using _Scripts.LSO.Bug;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "New WeightChacSO", menuName = "LSO/Auction/WeightChac", order = 0)]
    public class LSO_WeightChac : LSO_BaseCharacter
    {
        [Header("무게 범위 값 포함")]
        public int minWeight;
        public int maxWeight;
        
        public override bool Comfort(LSO_BugInstance data)
        {
            if (!data.Bug.IsAble)
                return false;
            
            return minWeight <= data.Weight && data.Weight <= maxWeight;
        }
    }
}