using UnityEngine;

namespace _Scripts.LSO
{
    /// <summary>
    /// 가중치 뽑기를 사용하는 SO에 붙이는 추상 SO
    /// 공통부분을 추상클래스로 추출 함
    /// </summary>
    public abstract class LSO_WeightableSO : ScriptableObject
    {
        [Tooltip("높을 수록 잘 뽑힘")]
        [Min(0)] public int spawnWeight; // 기본값 설정
    }
}