using TMPro;
using UnityEngine;

namespace LSO._Scripts.LSO.Auction.UI
{
    public class LSO_BidderBubble : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameTxt;
        [SerializeField] private TextMeshProUGUI contentTxt;
        
        public void Setup(string personName, string content)
        {
            nameTxt.text = personName;
            contentTxt.text = content;
        }
    }
}