using UnityEngine;

namespace _Scripts.LSO.Bug.Data
{
    [CreateAssetMenu(fileName = "New BugSO", menuName = "LSO/Bug/BugSO", order = 0)]
    public sealed class LSO_BugSO : ScriptableObject
    {
        //데이터가 유효한지 확인
        public bool IsAble => !string.IsNullOrEmpty(bugName)
                              && !string.IsNullOrEmpty(description);
        
        public string bugName;
        [TextArea(3,10)]public string description;
        public Sprite icon;
        [Min(0)]public int defaultPrice;
        public LSO_RarityEnum rarity;
        public LSO_BugType bugType;

        public int minAge;
        public int maxAge;
        public int minWeight;
        public int maxWeight;
        [Header("Unknown이면 Data에서 램덤으로 정해줌, 다른 값을 넣으면 무조건 그 값만 나오게 됨")]
        public LSO_GenderType gender = LSO_GenderType.Unknown;

        private void OnValidate()
        {
            if (minAge < 0)
                minAge = 0;
            if (maxAge < 0)
                maxAge = 0;
            if (minAge > maxAge)
                minAge = maxAge;
            
            if  (minWeight < 0)
               minWeight = 0;
            if (maxWeight < 0)
               maxWeight = 0;
            if (minWeight > maxWeight)
                minWeight = maxWeight;
        }
    }
}