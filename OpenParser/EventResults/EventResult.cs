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

    public class EventResult<T>
    {
        public EventResult(LogEntry entry, T match)
        {
            Match = match;
            LogEntry = entry;
        }

        public T Match { get; set; }
        public LogEntry LogEntry { get; }
    }
}