using System.Collections.Generic;
using System.Linq;
using _Scripts.LSO.Auction.Data;
using LSO._Scripts.LSO.Auction.Person.Data;
using UnityEngine;

namespace _Scripts.LSO.Auction.PersonTable
{
    [CreateAssetMenu(fileName = "PersonTableSO", menuName = "LSO/PersonTableSO")]
    public class LSO_PersonTableSO : ScriptableObject
    {
        [SerializeField]private LSO_PersonSO[] persons;
        public IReadOnlyList<LSO_PersonSO> Persons => persons.ToList();
    }
}