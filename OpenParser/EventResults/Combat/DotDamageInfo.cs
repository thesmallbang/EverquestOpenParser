namespace OpenParser.EventResults.Combat
{
    public class DotDamageInfo : IDamageInfo
    {
        public DotDamageInfo(long amount, string spell)
        {
            Amount = amount;
            Spell = spell;
        }

        public string Spell { get; }
        public long Amount { get; }
    }
}