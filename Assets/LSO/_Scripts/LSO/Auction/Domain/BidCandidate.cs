using System;
using LSO._Scripts.LSO.Auction.Person.Data;

namespace LSO._Scripts.LSO.Auction.Domain
{
    /// <summary>
    /// 낙찰자 선택을 위한 구조
    /// </summary>
    public readonly struct BidCandidate : IEquatable<BidCandidate>
    {
        public readonly int Balance;
        public readonly LSO_PersonSO Person;
        
        public BidCandidate(int balance, LSO_PersonSO person)
        {
            Balance = balance;
            Person = person;
        }

        public bool Equals(BidCandidate other)
        {
            return Balance == other.Balance && Equals(Person, other.Person);
        }

        public override bool Equals(object obj)
        {
            return obj is BidCandidate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Balance, Person);
        }
    }
}