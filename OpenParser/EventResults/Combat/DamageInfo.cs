namespace OpenParser.EventResults.Combat
{
    public class DamageInfo : IDamageInfo
    {
        public DamageInfo(long amount, string damageType)
        {
            Amount = amount;
            DamageType = damageType;
        }

        public string DamageType { get; }
        public long Amount { get; }
    }
}