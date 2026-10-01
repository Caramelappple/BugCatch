using UnityEngine;

namespace _Scripts.LSO.Auction.Data
{
    [CreateAssetMenu(fileName = "New PersonSO", menuName = "LSO/Auction/PersonSO", order = 0)]
    public sealed class LSO_PersonSO : ScriptableObject
    {
        public string personName;
        public LSO_TasteSO Taste;
    }
}