using _Scripts.LSO.Auction.Data;
using _Scripts.LSO.Auction.Data.Taste;
using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO
{
    public class LSO_Test : MonoBehaviour
    {
        public LSO_TaxidermySO taxidermyData;
        public LSO_PersonSO personData;

        [ContextMenu("Test")]
        public void Test()
        {
            bool t = true;
            foreach (LSO_BaseCharacter character in personData.Taste.characters)
            {
                if (character.Comfort(taxidermyData.bugData))
                {
                    Debug.Log("통과");
                    continue;
                }
                Debug.Log("실패");
                t = false;

                break;
            }
            
            if (t)
                print((taxidermyData.bugData.defaultPrice 
                       + personData.Taste.bonusMoney
                       + taxidermyData.frameData.bonusPrice) 
                      * taxidermyData.frameData.bonusMultiplier);
        }
    }
}