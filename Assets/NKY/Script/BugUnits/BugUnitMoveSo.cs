using UnityEngine;

namespace NKY.Script.BugUnits
{
    [CreateAssetMenu(fileName = "BugMove", menuName = "So/Bug/Move", order = 0)]
    public class BugUnitMoveSo : ScriptableObject
    {
        [SerializeField] private Sprite bugSprite;
    }
}