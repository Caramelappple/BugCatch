using UnityEngine;

namespace _Scripts.LSO.Bug.Data
{
    [CreateAssetMenu(fileName = "New BugSO", menuName = "LSO/Bug/BugSO", order = 0)]
    public sealed class LSO_BugSO : ScriptableObject
    {
        public string bugName;
        public string description;
        public Sprite icon;
        public int defaultPrice;
        [Range(1, 3000)] public int weight;
        [Range(1, 13)] public int age;
        public LSO_RarityEnum rarity;
    }
}