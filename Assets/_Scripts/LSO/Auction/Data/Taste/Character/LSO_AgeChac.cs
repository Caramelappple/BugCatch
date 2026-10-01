using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "AgeChac", menuName = "LSO/Auction/AgeChac", order = 0)]
    public class LSO_AgeChac : LSO_BaseCharacter
    {
        [Header("나이의 범위값, 포함시켜서 계산한다")]
        public int minAge;
        public int maxAge;
        
        public override bool Comfort(LSO_BugSO data)
        {
            if (!data.IsAble) 
                return false;
            
            return minAge <= data.age && data.age <= maxAge;
        }
    }
}