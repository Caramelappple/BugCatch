using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.LSO.Auction.Data.Taste
{
    /// <summary>
    /// 취향을 정의 하는 SO
    /// 하위 SO를 조립해 하나의 완벽한 취향을 만든다.
    /// 예시) 샤링 특성
    /// 12살/ 날벌레 /여자
    /// </summary>
    [CreateAssetMenu(fileName = "TasteSO",menuName = "LSO/Auction/Taste")]
    public sealed class LSO_TasteSO : ScriptableObject
    {
        public string tasteName;
        public int bonusMoney;
        public List<LSO_BaseCharacter> characters;
    }
}