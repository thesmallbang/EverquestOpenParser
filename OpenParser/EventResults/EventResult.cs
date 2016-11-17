namespace OpenParser.EventResults
{
    public class EventResult
    {
        public EventResult(LogEntry entry)
        {
            LogEntry = entry;
        }

        public LogEntry LogEntry { get; }
    }
}