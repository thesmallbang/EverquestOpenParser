namespace OpenParser.HandlerObjects
{
    public interface IDamageInfo : ICombatInfo
    {
        string DamageType { get; }
        long Amount { get; }
    }
}