namespace OpenParser.Subscribers.Strategies.Say
{
    public interface ISayStrategy
    {
        HandlerObjects.Say GetSay(LogEntry entry);
        bool IsMatch(LogEntry entry);
    }
}