namespace OpenParser.Subscribers.Strategies.Combat
{
    public interface ICombatStrategy
    {
        HandlerObjects.Combat GetCombatInfo(LogEntry entry);
        bool IsMatch(LogEntry entry);
    }
}