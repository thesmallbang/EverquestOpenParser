namespace OpenParser.EventResults
{
    public interface IDamageInfo : ICombatInfo
    {
        string DamageType { get; }
        long Amount { get; }
    }
}