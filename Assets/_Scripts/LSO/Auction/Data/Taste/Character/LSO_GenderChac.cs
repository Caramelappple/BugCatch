using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "GenderChac", menuName = "LSO/Taste/Gender", order = 0)]
    public sealed class LSO_GenderChac : LSO_BaseCharacter
    {
        public LSO_GenderType gender;

        public override bool Comfort(LSO_BugSO data)
        {
            if (!data.IsAble)
                return false;
            
            return data.gender == gender;
        }
    }
}