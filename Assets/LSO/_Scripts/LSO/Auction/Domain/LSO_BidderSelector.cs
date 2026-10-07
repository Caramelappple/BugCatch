using System.Collections.Generic;
using LSO._Scripts.LSO.Auction.Person.Data;
using Random = UnityEngine.Random;

namespace LSO._Scripts.LSO.Auction.Domain
{
    public class LSO_BidderSelector : IBidderSelector
    {
        public LSO_PersonSO SelectPerson(IReadOnlyList<BidCandidate> candidates)
        {
            if (candidates.Count <= 0)
                return null;
            
            int index = 0;
            List<int> same = new List<int>();

            for (int i = 0; i < candidates.Count; i++)
            {
                //다르면 큰거 선택
                if (candidates[index].Balance < candidates[i].Balance)
                {
                    index = i;
                    same.Clear();
                }

                //같으면 둘중 랜덤으로 하나 선택
                if (candidates[index].Balance == candidates[i].Balance)
                    same.Add(i);
            }

            if (same.Count > 0)
                index = same[Random.Range(0, same.Count)];
            
            //제일 많은 사람 반환
            return candidates[index].Person;
        }
    }
}