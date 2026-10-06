using UnityEngine;

namespace _Scripts.LSO.Auction.Data
{
    [CreateAssetMenu(fileName = "New PersonText SO", menuName = "LSO/Person/TextSO", order = 0)]
    public sealed class LSO_PersonTextSO : ScriptableObject
    {
        //가격 제시 텍스트
        [TextArea(3,10)]public string[] raiseTexts;
        //포기 텍스트
        [TextArea(3,10)]public string[] failTexts;
        //성공 텍스트
        [TextArea(3, 10)] public string[] successTexts;
    }
}