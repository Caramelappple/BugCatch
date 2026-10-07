using _Scripts.LSO.Auction.Taste.Character;
using _Scripts.LSO.Bug;
using _Scripts.LSO.Bug.Data;
using LSO._Scripts.LSO.Bug;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "New AgeChacSO", menuName = "LSO/Auction/AgeChac", order = 0)]
    public class LSO_AgeChac : LSO_BaseCharacter
    {
        [Header("나이의 범위값, 포함시켜서 계산한다")]
        public int minAge;
        public int maxAge;
        
        public override bool Comfort(LSO_BugInstance data)
        {
            if (!data.Bug.IsAble) 
                return false;
            
            return minAge <= data.Age && data.Age <= maxAge;
        }
    }
}