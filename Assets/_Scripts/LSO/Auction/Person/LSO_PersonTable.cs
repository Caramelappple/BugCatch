using System.Collections.Generic;
using System.Linq;
using _Scripts.LSO.Auction.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction
{
    public class LSO_PersonTable : MonoBehaviour
    {
        public int maxPeoplePerRounds;
        
        [SerializeField]private LSO_PersonSO[] persons;
        public IReadOnlyList<LSO_PersonSO> Persons => persons.ToList();
    }
}