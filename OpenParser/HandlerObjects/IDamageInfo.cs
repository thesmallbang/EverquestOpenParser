namespace OpenParser.HandlerObjects
{
    public interface IDamageInfo : ICombatInfo
    {
        bool IsCritical { get; set; }
        long Amount { get; set; }
    }
}