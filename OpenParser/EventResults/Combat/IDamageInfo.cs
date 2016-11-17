namespace OpenParser.EventResults.Combat
{
    public interface IDamageInfo : ICombatInfo
    {
        long Amount { get; }
    }
}