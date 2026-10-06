using _Scripts.LSO.Bug.Data;
using UnityEngine;

namespace _Scripts.LSO.Bug
{
    public readonly struct LSO_BugInstance
    {
        public readonly LSO_BugSO Bug;
        public readonly LSO_GenderType Gender;
        public readonly int Age;
        public readonly int Weight;

        public LSO_BugInstance(LSO_BugSO bug)
        {
            Bug = bug;
            
            Gender = bug.gender;
            
            if (Bug.gender == LSO_GenderType.Unknown)
                Gender = Random.Range(0, 2) == 0 ? LSO_GenderType.Female : LSO_GenderType.Male;
            
            Age = Random.Range(bug.minAge, bug.maxAge + 1);
            
            Weight = Random.Range(bug.minWeight, bug.maxWeight + 1);
        }
    }
}