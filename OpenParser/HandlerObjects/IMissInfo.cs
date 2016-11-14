namespace OpenParser.HandlerObjects
{
    public interface IMissInfo : ICombatInfo
    {
        string AttemptType { get; set; }
        string MissType { get; set; }
    }
}