using _Scripts.LSO.Auction.Data;
using _Scripts.LSO.Auction.Data.Taste;
using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO
{
    public class LSO_Test : MonoBehaviour
    {
        public LSO_BugSO bugData;
        public LSO_PersonSO personData;

        [ContextMenu("Test")]
        public void Test()
        {
            foreach (LSO_BaseCharacter character in personData.Taste.characters)
            {
                if (character.Comfort(bugData))
                {
                    Debug.Log("통과");
                    continue;
                }

                break;
            }
        }
    }
}