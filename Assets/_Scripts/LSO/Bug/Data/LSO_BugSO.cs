using UnityEngine;

namespace _Scripts.LSO.Bug.Data
{
    [CreateAssetMenu(fileName = "New BugSO", menuName = "LSO/Bug/BugSO", order = 0)]
    public sealed class LSO_BugSO : ScriptableObject
    {
        //데이터가 유효한지 확인
        public bool IsAble => !string.IsNullOrEmpty(bugName)
                               && !string.IsNullOrEmpty(description)
                               && icon != null
                               && rarity != default
                               && gender != LSO_GenderType.Unknown
                               && bugType != default
                               && gender != default;
        
        public string bugName;
        [TextArea(3,10)]public string description;
        public Sprite icon;
        public int defaultPrice;
        [Range(1, 3000)] public int weight;
        [Range(1, 13)] public int age;
        public LSO_RarityEnum rarity;
        public LSO_GenderType gender;
        public LSO_BugType bugType;
    }
}