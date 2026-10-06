using UnityEngine;

namespace _Scripts.LSO.Bug.Data
{
    [CreateAssetMenu(fileName = "New TaxidermySO", menuName = "LSO/Bug/Taxidermy", order = 0)]
    public class LSO_TaxidermySO : ScriptableObject
    {
        //원본 벌레 데이터
        public LSO_BugSO bugData;
        //박제본의 정확도(퀄리티)
        [Range(0, 100)] public float accuracy;
        //테두리 SO
        public LSO_FrameSO frameData;
    }
}