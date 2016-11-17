namespace OpenParser.EventResults.Combat
{
    public class DotDamageInfo : IDamageInfo
    {
        public DotDamageInfo(long amount, string damageSource)
        {
            Amount = amount;
            Spell = damageSource;
        }

        public string Spell { get; }
        public long Amount { get; }
    }
}