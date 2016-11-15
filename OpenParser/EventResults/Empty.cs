namespace OpenParser.EventResults
{
    public class Empty
    {
        private Empty(LogEntry entry)
        {
            LogEntry = entry;
        }

        public LogEntry LogEntry { get; }

        public static Empty Instance(LogEntry entry) => new Empty(entry);
    }
}