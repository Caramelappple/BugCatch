namespace _Scripts.LSO.Bug.Data
{
    public enum LSO_GenderType
    {
        Unknown,
        Male,
        Female
    }

    public struct LSO_Gender
    {
        private readonly LSO_GenderType _type;
        public LSO_Gender(LSO_GenderType type) => _type = type;

        // 반대 성별 반환
        public static LSO_Gender operator !(LSO_Gender g)
        {
            if (g._type == LSO_GenderType.Male) return new LSO_Gender(LSO_GenderType.Female);
            if (g._type == LSO_GenderType.Female) return new LSO_Gender(LSO_GenderType.Male);
            return new LSO_Gender(LSO_GenderType.Unknown);
        }
        
        public override string ToString() => _type.ToString();
    }
}