using System;
using _Scripts.LSO.Bug;
using LSO._Scripts.LSO.Bug;

namespace LSO._Scripts.LSO.Taxidermy
{
    public readonly struct LSO_TaxidermyData
    {
        public readonly LSO_BugInstance Bug;
        public readonly float PinAccuracy;

        public LSO_TaxidermyData(LSO_BugInstance bugSo, float pinAccuracy)
        {
            Bug = bugSo;
            PinAccuracy = Math.Clamp(pinAccuracy, 0f, 1f);
        }
    }
}