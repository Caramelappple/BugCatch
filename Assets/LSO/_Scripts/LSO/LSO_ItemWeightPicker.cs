using System.Collections.Generic;
using _Scripts.LSO;
using UnityEngine;

namespace LSO._Scripts.LSO
{
    /// <summary>
    /// 가중치 뽑기를 해주는 스태틱 클래스
    /// </summary>
    public static class LSO_ItemWeightPicker
    {
        public static List<T> PickMany<T>(int pickCount, IReadOnlyList<T> originalPool) where T : LSO_WeightableSO
        {
            //예외 처리 코드
            if (originalPool == null || originalPool.Count == 0 || pickCount <= 0)
                return new List<T>();
            
            if (pickCount > originalPool.Count)
                pickCount = originalPool.Count;
            
            if (originalPool.Count == 1)
                return new List<T> { originalPool[0] };
            
            //원본 풀 저장
            List<T> pool = new List<T>(originalPool);
            //반환할 풀 생성
            List<T> selectedItems = new List<T>(pickCount);
            
            //뽑는 수만큼 반복
            for (int i = 0; i < pickCount; i++)
            {
                //총 가중치
                int totalWeight = 0;
                foreach (var item in pool)
                    totalWeight += item.spawnWeight;

                if (totalWeight <= 0) break;
                
                int randomValue = Random.Range(0, totalWeight);
                int currentSum = 0;
                
                for (int j = 0; j < pool.Count; j++)
                {
                    currentSum += pool[j].spawnWeight;
                    if (randomValue < currentSum)
                    {
                        selectedItems.Add(pool[j]);
                        pool.RemoveAt(j);
                        break;
                    }
                }
            }
            
            //반환
            return selectedItems;
        }
    }
}