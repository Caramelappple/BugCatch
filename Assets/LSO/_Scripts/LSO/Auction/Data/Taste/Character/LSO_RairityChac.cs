using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "New RarityChacSO", menuName = "LSO/Auction/RarityChac", order = 0)]
    public class LSO_RairityChac : LSO_BaseCharacter
    {
        public LSO_RarityEnum rarity;
        
        public override bool Comfort(LSO_BugSO data)
        {
            if (data.IsAble)
                return false;
            
            return data.rarity == rarity;
        }
    }
}