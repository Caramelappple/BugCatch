using _Scripts.LSO.Auction.Taste.Character;
using _Scripts.LSO.Bug;
using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste.Character
{
    [CreateAssetMenu(fileName = "New BugTypeChacSO", menuName = "LSO/Auction/BugTypeChac", order = 0)]
    public class LSO_BugTypeChac : LSO_BaseCharacter
    {
        public LSO_BugType bugType;


        public override bool Comfort(LSO_BugInstance data)
        {
            if (!data.Bug.IsAble)
                return false;

            return data.Bug.bugType.HasFlag(bugType);
        }
    }
}