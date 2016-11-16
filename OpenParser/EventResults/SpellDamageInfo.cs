namespace OpenParser.EventResults
{
    public class SpellDamageInfo : IDamageInfo
    {
        public SpellDamageInfo(long amount, string damageSource)
        {
            Amount = amount;
            Spell = damageSource;
        }

        public string Spell { get; }
        public long Amount { get; }
    }
}