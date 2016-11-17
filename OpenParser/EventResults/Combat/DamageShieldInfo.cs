namespace OpenParser.EventResults.Combat
{
    public class DamageShieldInfo : IDamageInfo
    {
        public DamageShieldInfo(long amount, string damageType, string affectType)
        {
            Amount = amount;
            DamageType = damageType;
            AffectType = affectType;
        }

        public string AffectType { get; }
        public string DamageType { get; }
        public long Amount { get; }
    }
}