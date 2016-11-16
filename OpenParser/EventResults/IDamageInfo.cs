namespace OpenParser.EventResults
{
    public interface IDamageInfo : ICombatInfo
    {
        long Amount { get; }
    }
}