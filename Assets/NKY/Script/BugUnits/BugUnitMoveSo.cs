using UnityEngine;

namespace NKY.Script.BugUnits
{
    [CreateAssetMenu(fileName = "BugMove", menuName = "So/Bug/Move", order = 0)]
    public class BugUnitMoveSo : ScriptableObject
    {
        public Sprite bugSprite;
        [Min(0)] public float moveSpeed;
        [Range(0, 90f)] public float reflectAngle;
        [Range(0.5f, 10f)] public float turnDelay;
        [Range(0, 180f)] public float turnAngle;
    }
}