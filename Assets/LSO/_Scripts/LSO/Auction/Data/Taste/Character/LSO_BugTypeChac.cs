using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "New BugTypeChacSO", menuName = "LSO/Auction/BugTypeChac", order = 0)]
    public class LSO_BugTypeChac : LSO_BaseCharacter
    {
        public LSO_BugType bugType;
        
        public override bool Comfort(LSO_BugSO data)
        {
            if (!data .IsAble)
                return false;

            return data.bugType == bugType;
        }
    }
}