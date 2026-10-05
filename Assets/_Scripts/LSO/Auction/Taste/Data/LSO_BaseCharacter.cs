using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste
{
    /// <summary>
    /// 취향 SO를 구성하는 특징 SO
    /// 예) 나이/성별/가격 등등
    /// </summary>
    public class LSO_BaseCharacter : ScriptableObject
    {
        //특징 이름
        public string characterName;
        //조건을 만족하는지 검사
        public virtual bool Comfort(LSO_BugSO data)
        {
            if (!data.IsAble)
                return false;
            return true;
        }
    }
}