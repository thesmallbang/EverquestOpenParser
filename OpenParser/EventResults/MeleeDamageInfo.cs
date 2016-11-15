namespace OpenParser.EventResults
{
    public class MeleeDamageInfo : IDamageInfo
    {
        public MeleeDamageInfo(long amount, string damageType)
        {
            Amount = amount;
            DamageType = damageType;
        }

        public string DamageType { get; }
        public long Amount { get; }
    }
}