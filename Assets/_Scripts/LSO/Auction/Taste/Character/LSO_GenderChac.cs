using _Scripts.LSO.Auction.Taste.Character;
using _Scripts.LSO.Bug;
using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "New GenderChacSO", menuName = "LSO/Auction/GenderChac", order = 0)]
    public sealed class LSO_GenderChac : LSO_BaseCharacter
    {
        public LSO_GenderType gender;

        public override bool Comfort(LSO_BugInstance data)
        {
            if (!data.Bug.IsAble)
                return false;
            
            return data.Gender == gender;
        }
    }
}