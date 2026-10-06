using System.Collections.Generic;
using _Scripts.LSO.Auction.Taste.Character;
using _Scripts.LSO.Bug;
using UnityEngine;

namespace _Scripts.LSO.Auction.Taste.Data
{
    /// <summary>
    /// 취향을 정의 하는 SO
    /// 하위 SO를 조립해 하나의 완벽한 취향을 만든다.
    /// 예시) 샤링 취향
    /// 12살/ 날벌레 /여자
    /// </summary>
    [CreateAssetMenu(fileName = "TasteSO",menuName = "LSO/Auction/Taste")]
    public sealed class LSO_TasteSO : ScriptableObject
    {
        public string tasteName;
        public float bonusPercent;
        public List<LSO_BaseCharacter> characters;

        public bool IsTasteComfort(LSO_BugInstance bug)
        {
            if (characters.Count <= 0)
                return false;

            bool result = true;

            foreach (LSO_BaseCharacter baseChar in characters)
            {
                if (baseChar == null)
                {
                    result = false;
                    break;
                }
                
                result = result && baseChar.Comfort(bug);
            }

            return result;
        }
    }
}