using _Scripts.LSO.Bug;
using _Scripts.LSO.Bug.Data;
using LSO._Scripts.LSO.Bug;
using UnityEngine;

namespace _Scripts.LSO.Auction.Taste.Character
{
    /// <summary>
    /// 취향 SO를 구성하는 특징 SO
    /// 예) 나이/성별/가격 등등
    /// </summary>
    public abstract class LSO_BaseCharacter : ScriptableObject
    {
        //특징 이름
        public string characterName;
        //조건을 만족하는지 검사
        public abstract bool Comfort(LSO_BugInstance data);
    }
}