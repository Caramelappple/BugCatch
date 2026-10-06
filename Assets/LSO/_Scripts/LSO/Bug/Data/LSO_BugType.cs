using System;

namespace _Scripts.LSO.Bug.Data
{
    //비트로 1,2,4,8 한 이유는 더했을때 다른값이 나와서이다
    [Flags]
    public enum LSO_BugType
    {
        Flying = 1 << 0,
        Ground = 1 << 1,
        Armor = 1 << 2,
        Water = 1 << 3
    }
}