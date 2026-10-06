using UnityEngine;

namespace NKY.Script.BugUnits
{
    [CreateAssetMenu(fileName = "BugMove", menuName = "So/Bug/Move", order = 0)]
    public class BugUnitMoveSo : ScriptableObject
    {
        public Sprite bugSprite;
        [Min(0)] public float moveSpeed;
        [Range(0, 90)] public float maxReflectAngle;
    }
}